using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class BallPickup : MonoBehaviour

{
    public GameObject player1;
    public GameObject player2;
    public float pickupDistance = 2f;
    public GameObject questionCanvas;

    private GameObject currentPlayer;
    private bool isPickedUp = false;

    void Start()
    {
        // Ensure that the questionCanvas is initially inactive
        questionCanvas.SetActive(false);
    }

    void Update()
    {
        // Check for the 'H' key press regardless of whether the ball is picked up or not
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowQuestionCanvas();
        }

        // Check for ball pickup if it's not already picked up
        if (!isPickedUp)
        {
            float distanceToPlayer1 = Vector3.Distance(transform.position, player1.transform.position);
            float distanceToPlayer2 = Vector3.Distance(transform.position, player2.transform.position);

            if (distanceToPlayer1 < pickupDistance && Input.GetKeyDown(KeyCode.E))
            {
                PickUp(player1);
            }
            else if (distanceToPlayer2 < pickupDistance && Input.GetKeyDown(KeyCode.Return))
            {
                PickUp(player2);
            }
        }
        else
        {
            // If the ball is picked up, move it to the position of the current player
            transform.position = currentPlayer.transform.position;
        }
    }

    void PickUp(GameObject player)
    {
        isPickedUp = true;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.SetParent(player.transform);
        transform.localPosition = Vector3.zero;
        currentPlayer = player;
    }

    void ShowQuestionCanvas()
    {
        // Show the question canvas
        questionCanvas.SetActive(true);
    }
}