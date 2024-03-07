using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallPickup : MonoBehaviour
{
    // Reference to the question canvas
    public GameObject questionCanvas;

    // Array of questions
    public string[] questions;

    // UI Text element to display the question
    public Text questionText;

    // Player controllers
    public GameObject player1Controller;
    public GameObject player2Controller;

    // Reference to the ball
    public GameObject ball;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player picks up the ball
        if (other.CompareTag("Player"))
        {
            // Randomly select a question from the array
            string randomQuestion = questions[Random.Range(0, questions.Length)];

            // Display the random question on the UI canvas
            questionText.text = randomQuestion;
            questionCanvas.SetActive(true);

            // Pause the game or disable player movement while the question is displayed
            Time.timeScale = 0f;
        }
    }

    // Call this method when the player answers the question
    public void AnswerQuestion(bool correctAnswer)
    {
        if (correctAnswer)
        {
            // Give the ball to the current player
            if (player1Controller.GetComponent<PlayerController>().hasBall)
            {
                player1Controller.GetComponent<PlayerController>().hasBall = false;
                player2Controller.GetComponent<PlayerController>().hasBall = true;
            }
            else
            {
                player1Controller.GetComponent<PlayerController>().hasBall = true;
                player2Controller.GetComponent<PlayerController>().hasBall = false;
            }
        }
        else
        {
            // Give the ball to the other player
            if (player1Controller.GetComponent<PlayerController>().hasBall)
            {
                player1Controller.GetComponent<PlayerController>().hasBall = false;
                player2Controller.GetComponent<PlayerController>().hasBall = true;
            }
            else
            {
                player1Controller.GetComponent<PlayerController>().hasBall = true;
                player2Controller.GetComponent<PlayerController>().hasBall = false;
            }
        }

        // Hide the question canvas and resume the game
        questionCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}