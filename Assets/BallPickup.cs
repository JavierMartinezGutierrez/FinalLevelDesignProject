using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallPickup : MonoBehaviour
{
    // Variables to store references to both player GameObjects
    public GameObject player1;
    public GameObject player2;

    // Variable to store the distance threshold for picking up the ball
    public float pickupDistance = 2f;

    // Variable to keep track of which player holds the ball
    private GameObject currentPlayer;

    // Variable to check if the ball is currently picked up
    private bool isPickedUp = false;

    void Update()
    {
        // Check if the ball is not currently picked up
        if (!isPickedUp)
        {
            // Calculate the distance between the ball and each player
            float distanceToPlayer1 = Vector3.Distance(transform.position, player1.transform.position);
            float distanceToPlayer2 = Vector3.Distance(transform.position, player2.transform.position);

            // If the distance is less than the pickup distance threshold and the player presses a key (e.g., "E"), pick up the ball
            if (distanceToPlayer1 < pickupDistance && Input.GetKeyDown(KeyCode.E))
            {
                PickUp(player1);
            }
            else if (distanceToPlayer2 < pickupDistance && Input.GetKeyDown(KeyCode.Return)) // Assuming Return key is used for player 2
            {
                PickUp(player2);
            }
        }
        else
        {
            // If the ball is picked up, set its position to the player's position
            transform.position = currentPlayer.transform.position;
        }
    }

    void PickUp(GameObject player)
    {
        // Set isPickedUp flag to true
        isPickedUp = true;

        // Disable the ball's Rigidbody so it doesn't fall or collide with other objects
        GetComponent<Rigidbody>().isKinematic = true;

        // Attach the ball to the player
        transform.SetParent(player.transform);

        // Set the current player who holds the ball
        currentPlayer = player;
    }
}