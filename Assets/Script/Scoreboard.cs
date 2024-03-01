using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    internal IEnumerable<object> questions;

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
        object value = playerScore++;
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
        computerPlayerScoreText.text = "Computer Player Score: " + computerPlayerScoreText.ToString();
        secondPlayerScoreText.text = "Second Player Score: " + secondPlayerScore.ToString();
    }

    void EndRound()
    {
        isRoundOver = true;

        // Determine winner
        if (playerScore > int.Parse(computerPlayerScoreText.text) && playerScore > int.Parse(secondPlayerScoreText.text))
        {
            // Player wins
        }
        if (int.Parse(playerScoreText.text) > computerPlayerScore && int.Parse(playerScoreText.text) > secondPlayerScore)
        {
            // Player wins
        }
        else
        {
            Debug.Log("It's a tie!");
            // Handle tie condition
        }
        SceneManager.LoadScene("ResultsScreen");
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