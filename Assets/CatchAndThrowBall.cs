using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CatchAndThrowBall : MonoBehaviour
{
    private bool ballCaught = false;
    private GameObject caughtBall;
    public GameObject popupCanvas; // Reference to the Canvas GameObject

    void Update()
    {
        if (!ballCaught)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f); // Adjust the radius as needed
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Ball"))
                {
                    ballCaught = true;
                    caughtBall = collider.gameObject;
                    Rigidbody ballRB = caughtBall.GetComponent<Rigidbody>();
                    ballRB.isKinematic = true;
                    caughtBall.layer = 8; // Set to a valid layer index within the range [0...31]
                    caughtBall.transform.parent = transform;
                    caughtBall.transform.localPosition = Vector3.zero;
                    ShowPopup(); // Show the popup window when the ball is caught
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 throwDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
                ThrowBall(throwDirection);
            }
        }
    }


    void ThrowBall(Vector3 direction)
    {
        Rigidbody ballRB = caughtBall.GetComponent<Rigidbody>();
        ballRB.isKinematic = false;

        caughtBall.layer = LayerMask.NameToLayer("Default");

        // Detach the ball from the catcher
        caughtBall.transform.parent = null;

        // Apply force to throw the ball
        ballRB.velocity = direction * 10f; // Adjust the force as needed

        // Reset ballCaught flag
        ballCaught = false;

        // Reset reference to caughtBall
        caughtBall = null;

        HidePopup(); // Hide the popup window when the ball is thrown
    }

    // Method to show the popup window (enable the Canvas)
    void ShowPopup()
    {
        popupCanvas.SetActive(true);
    }

    // Method to hide the popup window (disable the Canvas)
    void HidePopup()
    {
        popupCanvas.SetActive(false);
    }
}
