using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float throwForce = 10f;
    public Transform throwPoint;
    public LayerMask ballLayer;

    void Update()
    {
        if (Input.GetButtonDown("Catch"))
        {
            TryCatch();
        }

        if (Input.GetButtonDown("Throw"))
        {
            TryThrow();
        }
    }

    void TryCatch()
    {
        // Raycast to check if there's a ball in front of the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f, ballLayer))
        {
            // Catch logic - for example, destroy the ball
            Destroy(hit.collider.gameObject);
        }
    }

    void TryThrow()
    {
        // Throw logic - for example, instantiate a new ball and throw it
        GameObject ball = Instantiate(Resources.Load("BallPrefab"), throwPoint.position, Quaternion.identity) as GameObject;

        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}
