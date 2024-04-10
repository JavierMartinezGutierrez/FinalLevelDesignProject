using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    public KeyCode catchThrowKey; // Define the key for catching/throwing
    public float catchRange = 2f; // Define the range within which the player can catch the ball
    public float throwForce = 10f; // Define the force with which the ball is thrown

    public Canvas questionCanvas; // Reference to the canvas for displaying questions
    public MultipleChoice multipleChoiceScript;

    private Rigidbody rb;
    private GameObject ball;
    private bool isHoldingBall = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindWithTag("Ball"); // Assuming the ball has a tag "Ball"

        if (questionCanvas == null)
        {
            Debug.LogError("Question canvas reference is not set!");
        }
        else
        {
            questionCanvas.gameObject.SetActive(false); // Ensure canvas is initially deactivated
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(catchThrowKey))
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
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = true;
        isHoldingBall = true;
    }

    void ThrowBall()
    {
        ball.transform.SetParent(null);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        ballRigidbody.isKinematic = false;
        ballRigidbody.velocity = transform.forward * throwForce;
        isHoldingBall = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if collided with another player
        {
            Debug.Log("Collision with another player detected!"); // Debug log to verify collision detection
            DisplayQuestion();
            multipleChoiceScript.ShowRandomQuestion();
        }
    }

    void DisplayQuestion()
    {
        // Activate the canvas to display the question
        questionCanvas.gameObject.SetActive(true);
    }
}
