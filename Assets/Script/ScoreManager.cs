using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    internal static ScoreManager instance; // Singleton instance

    public Text player1ScoreText; // Reference to the UI Text element for Player 1 score
    public Text player2ScoreText; // Reference to the UI Text element for Player 2 score
    public Text timerText; // Reference to the UI Text element for displaying the timer

    public float gameDuration = 60f; // Duration of the game in seconds
    private float timer; // Timer variable

    private bool gameIsOver = false; // Flag to track whether the game is over

    private int player1Score = 0; // Player 1 score
    private int player2Score = 0; // Player 2 score

    private void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject); // Destroy duplicate instances
    }

    private void Start()
    {
        timer = gameDuration; // Initialize timer
        UpdateScoreText(); // Update score text
    }

    private void Update()
    {
        // Check if the game is over
        if (!gameIsOver)
        {
            // Update the timer
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                // Game over, handle end game logic here
                EndGame();
            }
        }
    }

    // Method to end the game
    private void EndGame()
    {
        gameIsOver = true;
        // Stop any game-related activities (e.g., disable player input, show game over screen, etc.)
        Debug.Log("Game Over!");
    }

    // Method to update Player 1 score
    public void UpdatePlayer1Score(int points)
    {
        player1Score += points;
        UpdateScoreText();
    }

    // Method to update Player 2 score
    public void UpdatePlayer2Score(int points)
    {
        player2Score += points;
        UpdateScoreText();
    }

    // Method to handle when Player 1 hits the ball
    public void Player1HitBall()
    {
        // Implement your scoring logic here for when Player 1 hits the ball
        // For example, you can increment Player 1's score
        UpdatePlayer1Score(1); // Increment Player 1's score by 1
    }

    // Method to award points when a player answers a question correctly
    public void AnswerQuestionCorrectly(int playerNumber, int points)
    {
        if (playerNumber == 1)
            UpdatePlayer1Score(points); // Update Player 1's score
        else if (playerNumber == 2)
            UpdatePlayer2Score(points); // Update Player 2's score
                                        // You can extend this logic for more players if needed
        Debug.Log("Player " + playerNumber + " answered correctly!");
    }
    public void AnswerQuestionIncorrectly(int playerNumber, int points)
    {
        if (playerNumber == 1)
            UpdatePlayer1Score(-points); // Deduct points from Player 1's score
        else if (playerNumber == 2)
            UpdatePlayer2Score(-points); // Deduct points from Player 2's score
                                         // You can extend this logic for more players if needed
        Debug.Log("Player " + playerNumber + " answered incorrectly!");
    }
    // Method to update the timer text
    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to update the score text
    private void UpdateScoreText()
    {
        player1ScoreText.text = "Player 1: " + player1Score;
        player2ScoreText.text = "Player 2: " + player2Score;
    }

    // Method to increase the score by a certain amount
    public void IncreaseScore(int pointsToAdd)
    {
        player1Score += pointsToAdd; // Assuming we are increasing Player 1's score for now
        UpdateScoreText();
    }

    // Method to decrease the score by a certain amount
    public void DecreaseScore(int pointsToDeduct)
    {
        player1Score -= pointsToDeduct; // Assuming we are decreasing Player 1's score for now
        UpdateScoreText();
    }

}
