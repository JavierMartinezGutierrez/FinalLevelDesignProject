using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text timerText;
    public Text playerScoreText;
    public Text computerPlayerScoreText;
    public Text secondPlayerScoreText;
    public float roundDuration = 60f;
    private float timer;
    private int playerScore = 0;
    private int computerPlayerScore = 0;
    private int secondPlayerScore = 0;
    private bool isRoundOver = false;

    void Start()
    {
        timer = roundDuration;
        UpdateTimerText();
    }

    void Update()
    {
        if (!isRoundOver)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                EndRound();
            }
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.FloorToInt(timer).ToString();
    }

    public void PlayerHit()
    {
        playerScore++;
        UpdateScoreText();
    }

    public void ComputerPlayerHit()
    {
        computerPlayerScore++;
        UpdateScoreText();
    }

    public void SecondPlayerHit()
    {
        secondPlayerScore++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        playerScoreText.text = "Player Score: " + playerScore.ToString();
        computerPlayerScoreText.text = "Computer Player Score: " + computerPlayerScore.ToString();
        secondPlayerScoreText.text = "Second Player Score: " + secondPlayerScore.ToString();
    }

    void EndRound()
    {
        isRoundOver = true;

        // Determine winner
        if (playerScore > computerPlayerScore && playerScore > secondPlayerScore)
        {
            Debug.Log("Player wins!");
            // Implement win logic for story mode
        }
        else if (computerPlayerScore > playerScore && computerPlayerScore > secondPlayerScore)
        {
            Debug.Log("Computer Player wins!");
            // Implement lose logic for story mode
        }
        else
        {
            Debug.Log("It's a tie!");
            // Handle tie condition
        }
    }

    internal void AddPlayerPoints()
    {
        throw new NotImplementedException();
    }

    internal void AddAIPoints()
    {
        throw new NotImplementedException();
    }

    internal void AddPlayer2Points()
    {
        throw new NotImplementedException();
    }
}