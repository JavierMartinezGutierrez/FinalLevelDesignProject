using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text player1ScoreText;
    public Text player2ScoreText;
    public Text aiScoreText;

    private int player1Score = 0;
    private int player2Score = 0;
    private int aiScore = 0;

    void Start()
    {
        UpdateScoreboard();
    }

    // Function to update the scoreboard UI
    void UpdateScoreboard()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score;
        player2ScoreText.text = "Player 2 Score: " + player2Score;
        aiScoreText.text = "AI Score: " + aiScore;
    }

    // Function to add points to player 1's score
    public void AddPlayer1Points(int points)
    {
        player1Score += points;
        UpdateScoreboard();
    }

    // Function to add points to player 2's score
    public void AddPlayer2Points(int points)
    {
        player2Score += points;
        UpdateScoreboard();
    }

    // Function to add points to AI's score
    public void AddAIScore(int points)
    {
        aiScore += points;
        UpdateScoreboard();
    }
}