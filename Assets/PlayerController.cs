using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode catchKey; // Key to catch the ball
    public KeyCode throwKey;
    public float catchRange = 2f;
    public float throwForce = 10f;

    private Rigidbody rb;
    private GameObject ball;
    private bool isHoldingBall = false;
    internal bool hasBall;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball"); // Assuming the ball has a tag "Ball"
    }

    void Update()
    {
        if (Input.GetKeyDown(catchKey))
        {
            if (!isHoldingBall)
            {
                if (IsBallInRange())
                {
                    GrabBall();
                }
            }
            else
            {
                ThrowBall();
            }
        }
    }

    
     bool IsBallInRange()
    {
        float distance = Vector3.Distance(transform.position, ball.transform.position);
        return distance <= catchRange;
    }

    void GrabBall()
    {
        ball.transform.SetParent(transform);
        ball.GetComponent<Rigidbody>().isKinematic = true;
        isHoldingBall = true;
    }

    void ThrowBall()
    {
        ball.transform.SetParent(null);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false;
        ballRigidbody.velocity = transform.forward * throwForce; // Throw the ball in the forward direction of the player
        isHoldingBall = false;
    }
}
