using System;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;

    // Public variable to control the throw force
    public float throwForce = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Remove the freeze constraints to allow physics to affect the ball immediately
        rb.constraints = RigidbodyConstraints.None;
    }

    // Method to release the ball with the specified throw direction
    public void ReleaseBall(Vector3 throwDirection)
    {
        // Reset the constraints to allow the ball to move
        rb.constraints = RigidbodyConstraints.None;
        // Set the Rigidbody to non-kinematic to allow physics to affect it
        rb.isKinematic = false;
        // Apply a force to the ball in the specified direction with the specified force magnitude
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // Debug log to print out the force vector being applied
        Debug.Log("Force applied: " + (throwDirection * throwForce).ToString("F2"));
    }

    // Method to check if the ball is held by a player
    public bool IsHeld()
    {
        return isHeld;
    }

    // Method to set the held state of the ball
    public void SetHeld(bool held)
    {
        isHeld = held;
    }

    // Add other methods or variables as needed

  // Method to handle the ball being caught by a player  // Method to handle the ball being caught by a player
    public void Caught()
    {
        // Set the held state of the ball to true
        SetHeld(true);
        // Set the Rigidbody to kinematic to stop physics from affecting it
        rb.isKinematic = true;
        // Set the parent of the ball to the player's transform to make it move with the player
        transform.SetParent(GameObject.FindWithTag("Player").transform);
    }
    // Method to handle the ball being thrown by a player
    public void Thrown(Vector3 throwDirection)
    {
        // Set the held state of the ball to false
        SetHeld(false);
        // Reset the parent of the ball to null to stop it from moving with the player
        transform.SetParent(null);
        // Release the ball with the specified throw direction
        ReleaseBall(throwDirection);
    }
    // Method to handle the ball being caught by a player
   
}