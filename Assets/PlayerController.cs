using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode catchKey = KeyCode.E; // Define the key to catch/throw the ball
    public float catchRange = 2f; // Define the range within which the player can catch the ball
    public float throwForce = 10f; // Define the force with which the ball is thrown

    private Rigidbody rb;
    private GameObject ball;
    private bool isHoldingBall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball"); // Assuming the ball has a tag "Ball"
    }

    void Update()
    {
        // Check if the player presses the catch key
        if (Input.GetKeyDown(catchKey))
        {
            // If the player is not holding the ball
            if (!isHoldingBall)
            {
                // Check if the ball is in range
                if (IsBallInRange())
                {
                    // Grab the ball
                    GrabBall();
                }
            }
            // If the player is holding the ball
            else
            {
                // Throw the ball
                ThrowBall();
            }
        }
    }

    // Check if the ball is within the catch range of the player
    bool IsBallInRange()
    {
        float distance = Vector3.Distance(transform.position, ball.transform.position);
        return distance <= catchRange;
    }

    // Grab the ball
    void GrabBall()
    {
        // Set the player as the parent of the ball
        ball.transform.SetParent(transform);

        // Disable the ball's Rigidbody so it doesn't fall or collide with other objects
        ball.GetComponent<Rigidbody>().isKinematic = true;

        // Set the flag to indicate that the player is holding the ball
        isHoldingBall = true;
    }

    // Throw the ball
    void ThrowBall()
    {
        // Detach the ball from the player
        ball.transform.SetParent(null);

        // Enable the ball's Rigidbody so it can move freely
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false;

        // Apply a force to the ball in the forward direction of the player
        ballRigidbody.velocity = transform.forward * throwForce;

        // Reset the flag to indicate that the player is no longer holding the ball
        isHoldingBall = false;
    }
}
