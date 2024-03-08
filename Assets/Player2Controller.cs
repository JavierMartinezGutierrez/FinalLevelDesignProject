using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public KeyCode throwKey = KeyCode.Return; // Example throw key for player 2
    public KeyCode catchKey = KeyCode.RightControl; // Example catch key for player 2
    public string grabButton = "Fire2";
    private Rigidbody rb;
    private bool isHoldingBall = false;
    private GameObject heldBall;
    private KeyCode grabKey;

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
            TryGrabBall();
        }
    }

    private void TryCatchBall()
    {
        // Logic to detect nearby ball and pick it up for Player 2
        // This part can be similar to the previous script
    }

    private void ThrowBall()
    {
        // Logic to throw the held ball for Player 2
        // This part can be similar to the previous script
    }

    private void TryGrabBall()
    {
        // Logic to grab the nearby ball for Player 2
        // This part can be similar to the previous script
    }
}
