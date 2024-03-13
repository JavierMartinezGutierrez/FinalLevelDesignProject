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
    public float throwForce = 10f; // Adjust the throw force as needed

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
                    ballRB.isKinematic = true; // Disable physics for the caught ball
                    caughtBall.layer = 8; // Set to a valid layer index within the range [0...31]
                    caughtBall.transform.parent = transform;
                    caughtBall.transform.localPosition = Vector3.zero;
                    ShowPopup(); // Show the popup window when the ball is caught
                }
            }
        }
    }

    void ShowPopup()
    {
        // Show the popup canvas
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(true);
        }
    }

    // Method to hide the popup window (disable the Canvas)
    void HidePopup()
    {
        if (popupCanvas != null)
        {
            popupCanvas.SetActive(false);
        }
    }

    void ThrowBall(Vector3 direction)
    {
        if (ballCaught && caughtBall != null)
        {
            Rigidbody ballRB = caughtBall.GetComponent<Rigidbody>();
            ballRB.isKinematic = false; // Enable physics for the thrown ball
            caughtBall.layer = LayerMask.NameToLayer("Default"); // Reset the layer
            caughtBall.transform.parent = null; // Detach the ball from the catcher
            ballRB.velocity = direction * throwForce; // Apply force to throw the ball
            ballCaught = false; // Reset ballCaught flag
            caughtBall = null; // Reset reference to caughtBall
            HidePopup(); // Hide the popup window when the ball is thrown
        }
    }
}