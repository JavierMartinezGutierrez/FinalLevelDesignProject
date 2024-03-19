using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode player1CatchKey = KeyCode.E; // Player 1's catch/throw key
    public KeyCode player2CatchKey = KeyCode.O; // Player 2's catch/throw key
    public float catchRange = 2f; // Define the range within which a player can catch the ball
    public float throwForce = 10f; // Define the force with which the ball is thrown

    public Transform player1StartPos; // Starting position for Player 1
    public Transform player2StartPos; // Starting position for Player 2

    private GameObject ball;
    private bool player1IsHoldingBall = false;
    private bool player2IsHoldingBall = false;

    void Start()
    {
        ball = GameObject.FindWithTag("Ball"); // Assuming the ball has a tag "Ball"
    }

    void Update()
    {
        HandlePlayerInput(player1CatchKey, ref player1IsHoldingBall, player1StartPos.position);
        HandlePlayerInput(player2CatchKey, ref player2IsHoldingBall, player2StartPos.position);
    }

    void HandlePlayerInput(KeyCode catchKey, ref bool isHoldingBall, Vector3 startPos)
    {
        if (Input.GetKeyDown(catchKey))
        {
            if (!isHoldingBall)
            {
                if (IsBallInRange(startPos))
                {
                    GrabBall();
                    isHoldingBall = true;
                }
            }
            else
            {
                ThrowBall();
                isHoldingBall = false;
            }
        }
    }

    bool IsBallInRange(Vector3 startPos)
    {
        float distance = Vector3.Distance(startPos, ball.transform.position);
        return distance <= catchRange;
    }

    void GrabBall()
    {
        ball.transform.SetParent(transform);

        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = true;
    }

    void ThrowBall()
    {
        ball.transform.SetParent(null);

        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false;
        ballRigidbody.velocity = transform.forward * throwForce;
    }
}