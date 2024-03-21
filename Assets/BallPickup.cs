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
    public Canvas questionCanvas;

    private GameObject currentPlayer;
    private bool isPickedUp = false;

    void Start()
    {
        questionCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
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
            transform.position = currentPlayer.transform.position;
        }
    }

    void PickUp(GameObject player)
    {
        isPickedUp = true;
        GetComponent<Rigidbody>().isKinematic = true;
        transform.SetParent(player.transform);
        currentPlayer = player;

        // Check if the player got hit
        // For demonstration purposes, let's assume the player gets hit when 'H' key is pressed
        if (Input.GetKeyDown(KeyCode.H))
        {
            ShowQuestionCanvas();
        }
    }

    void ShowQuestionCanvas()
    {
        questionCanvas.gameObject.SetActive(true);
    }
}