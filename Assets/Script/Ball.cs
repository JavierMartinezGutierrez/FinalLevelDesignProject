using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public QuestionManager questionManager;
    public Transform player2Transform; // Position of the second player or AI
    public Scoreboard scoreboard;
    public float bounceForce = 10f;

  

  
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Handle collision with player
            Debug.Log("Ball collided with Player!");
            // Implement player collision logic here
        }
        // Check if the collision is with the AI
        else if (collision.gameObject.CompareTag("AI"))
        {
            // Handle collision with AI
            Debug.Log("Ball collided with AI!");
            // Implement AI collision logic here
        }
        // Check if the collision is with Player2
        else if (collision.gameObject.CompareTag("Player2"))
        {
            // Handle collision with Player2
            Debug.Log("Ball collided with Player2!");
            // Implement Player2 collision logic here
        }
        // You can add more conditions as needed

        // You can also access information about the collision
        ContactPoint contact = collision.contacts[0];
        Debug.Log("Collision point: " + contact.point);
    }
}

