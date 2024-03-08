using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public KeyCode throwKey = KeyCode.Space; // Example throw key for player 1
    public KeyCode catchKey = KeyCode.LeftControl; // Example catch key for player 1
    public string grabButton = "Grab";

    private Rigidbody rb;
    private bool isHoldingBall = false;
    private GameObject heldBall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Input detection for throw and catch actions for Player 1
        if (Input.GetKeyDown(throwKey) && isHoldingBall)
        {
            ThrowBall();
        }
        else if (Input.GetKeyDown(catchKey) && !isHoldingBall)
        {
            TryCatchBall();
        }
    }

    private void TryCatchBall()
    {
        // Logic to detect nearby ball and pick it up for Player 1
        // This part can be similar to the previous script
    }

    private void ThrowBall()
    {
        // Logic to throw the held ball for Player 1
        // This part can be similar to the previous script
    }
}
