using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Variables to store player's life and score
    private int life = 3;
    private int score = 0;

    // Flag to indicate if the player can throw the ball
    public bool CanThrowBall { get; set; }

    // Method to increase player's life
    public void IncreaseLife()
    {
        life++;
    }

    // Method to answer a question
    public bool AnswerQuestion(string question)
    {
        // Display the question and wait for the player's answer
        // You can implement your own UI for displaying questions and getting player input

        // For demonstration purposes, let's assume the player always answers correctly
        return true;
    }

    // Method to deduct a point from player's score
    public void LosePoint()
    {
        score--;
    }
}