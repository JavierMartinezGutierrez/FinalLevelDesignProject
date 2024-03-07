using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public KeyCode throwKey = KeyCode.Space;
    public KeyCode catchKey = KeyCode.LeftControl;
    public KeyCode grabKey = KeyCode.LeftShift; // Add grab key

    private Rigidbody rb;
    private bool isHoldingBall = false;
    private GameObject heldBall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Input detection for throw, catch, and grab actions for Player 1
        if (Input.GetKeyDown(throwKey) && isHoldingBall)
        {
            ThrowBall();
        }
        else if (Input.GetKeyDown(catchKey) && !isHoldingBall)
        {
            throw new NotImplementedException();
        }
        else if (Input.GetKeyDown(grabKey) && !isHoldingBall)
        {
            TryGrabBall(); // Call method for grab action
        }
    }

    private void ThrowBall()
    {
        throw new NotImplementedException();
    }

    private void TryGrabBall()
    {
        // Logic to detect and grab nearby ball for Player 1
        // This could be similar to the logic in TryCatchBall()
    }

    // Other methods for TryCatchBall(), ThrowBall(), and other functionalities...
}


