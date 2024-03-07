using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public KeyCode throwKey = KeyCode.Return; // Example throw key for Player 2
    public KeyCode catchKey = KeyCode.RightControl; // Example catch key for Player 2
    public KeyCode grabKey = KeyCode.RightShift; // Example grab key for Player 2

    private Rigidbody rb;
    private bool isHoldingBall = false;
    private GameObject heldBall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Input detection for throw, catch, and grab actions for Player 2
        if (Input.GetKeyDown(throwKey) && isHoldingBall)
        {
            ThrowBall();
        }
        else if (Input.GetKeyDown(catchKey) && !isHoldingBall)
        {
            TryCatchBall();
        }
        else if (Input.GetKeyDown(grabKey) && !isHoldingBall)
        {
            TryGrabBall(); // Call method for grab action
        }
    }

    private void TryCatchBall()
    {
        // Logic to detect and catch nearby ball for Player 2
        // Similar to TryCatchBall() in Player1Controller
    }

    private void ThrowBall()
    {
        // Logic to throw the held ball for Player 2
        // Similar to ThrowBall() in Player1Controller
    }

    private void TryGrabBall()
    {
        // Logic to detect and grab nearby ball for Player 2
        // Similar to TryGrabBall() in Player1Controller
    }

    // Other methods for TryCatchBall(), ThrowBall(), and other functionalities...
}
