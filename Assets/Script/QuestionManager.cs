using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject questionPanel;
    public Text questionText;
    public Text answerText;
    public int currentScore = 0;
    public int maxScore = 10;

    private void Start()
    {
        questionPanel.SetActive(false);
    }

    public void DisplayQuestion(string question, string answer)
    {
        questionText.text = question;
        answerText.text = answer;
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            currentScore++;
            if (currentScore >= maxScore)
            {
                // Handle winning condition
            }
        }
        else
        {
            // Drop the ball
            gameObject.SetActive(false);
        }
        questionPanel.SetActive(false);
    }

    internal void DisplayQuestion()
    {
        throw new NotImplementedException();
    }

    internal void DisplayQuestion(string question)
    {
        throw new NotImplementedException();
    }
}
