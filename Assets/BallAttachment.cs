using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttachment : MonoBehaviour
{
    public Transform playerTransform;
    public Transform ballTransform;
    public Vector3 ballOffset; // Offset for positioning the ball relative to the player
    public Vector3 ballRotation; // Rotation for orienting the ball relative to the player

    // Method to attach the ball to the player
    public void AttachBallToPlayer()
    {
        // Set the ball's parent to the player
        ballTransform.SetParent(playerTransform);

        // Adjust the position and rotation of the ball relative to the player
        ballTransform.localPosition = ballOffset;
        ballTransform.localRotation = Quaternion.Euler(ballRotation);
    }

    // Method to detach the ball from the player
    public void DetachBallFromPlayer()
    {
        // Set the ball's parent back to null to detach it from the player
        ballTransform.SetParent(null);
    }

    void Update()
    {
        // Check for player input to catch, throw, and grab the ball
        if (Input.GetButtonDown("Catch1"))
        {
            // Perform catch action for Player 1
            // You can call a method or trigger an event here
        }
        else if (Input.GetButtonDown("Catch2"))
        {
            // Perform catch action for Player 2
            // You can call a method or trigger an event here
        }

        if (Input.GetButtonDown("Throw1"))
        {
            // Perform throw action for Player 1
            // You can call a method or trigger an event here
        }
        else if (Input.GetButtonDown("Throw2"))
        {
            // Perform throw action for Player 2
            // You can call a method or trigger an event here
        }

        if (Input.GetButtonDown("Grab1"))
        {
            // Perform grab action for Player 1
            // You can call a method or trigger an event here
        }
        else if (Input.GetButtonDown("Grab2"))
        {
            // Perform grab action for Player 2
            // You can call a method or trigger an event here
        }
    }
}