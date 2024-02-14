using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    public QuestionManager questionManager;
    public Transform player2Transform; // Position of the second player or AI
    public Scoreboard scoreboard;
    public float bounceForce = 10f;

    private bool ballCaught = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI") || collision.gameObject.CompareTag("Player2"))
            {
                bool answerIsCorrect = /* Check if the answer is correct */ true; // Change this based on the player's answer

                if (answerIsCorrect)
                {
                    // Ball bounces back to the respective player
                    Rigidbody rb = GetComponent<Rigidbody>();
                    rb.velocity = (collision.gameObject.transform.position - transform.position).normalized * bounceForce;

                    // Update scoreboard if needed
                    if (collision.gameObject.CompareTag("Player"))
                    {
                        scoreboard.AddPlayerPoints();
                    }
                    else if (collision.gameObject.CompareTag("AI"))
                    {
                        scoreboard.AddAIPoints();
                    }
                    else if (collision.gameObject.CompareTag("Player2"))
                    {
                        scoreboard.AddPlayer2Points();
                    }
                }
                else
                {
                    // Ball is dead if the answer is wrong
                    ballCaught = false;
                }
            }
        }
        else
        {
            // Display multiple-choice question when the ball drops
            questionManager.DisplayQuestion();
        }
    }

    // Called when the ball is caught by the AI or second player
    public void BallCaught()
    {
        ballCaught = true;
    }

    // Called when the ball is not caught by anyone
    public void DeadBall()
    {
        ballCaught = false;
    }
}