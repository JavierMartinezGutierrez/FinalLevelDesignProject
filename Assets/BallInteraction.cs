using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    // Create an instance of the QuestionManager class
    private QuestionManager questionManager;

    // Flag to track if the ball is caught
    private bool ballCaught = false;

    void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && !ballCaught) // Player catches the ball
        {
            // Increase player's life
            player.IncreaseLife();

            // Enable player to throw the ball back
            player.CanThrowBall = true;

            ballCaught = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null && !ballCaught) // Player fails to catch the ball
        {
            // Ask a question
            string question = questionManager.GetRandomQuestion();
            bool answerCorrect = player.AnswerQuestion(question);

            if (!answerCorrect)
            {
                // Deduct a point from player's score if answer is incorrect
                player.LosePoint();
            }

            ballCaught = true;
        }
    }
}
