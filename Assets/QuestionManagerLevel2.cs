using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManagerLevel2 : MonoBehaviour
{
    // Define a class to represent each question
    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] options;
        public int correctOptionIndex;
    }

    // Define an array to hold the questions
    public Question[] questions;

    // Function to display a random question
    public void DisplayRandomQuestion()
    {
        int randomIndex = Random.Range(0, questions.Length);
        Question randomQuestion = questions[randomIndex];

        // Display the question
        Debug.Log(randomQuestion.question);

        // Display the options
        for (int i = 0; i < randomQuestion.options.Length; i++)
        {
            Debug.Log((char)(97 + i) + ") " + randomQuestion.options[i]);
        }

        // Store the correct answer
        int correctAnswerIndex = randomQuestion.correctOptionIndex;
        Debug.Log("Correct Answer Index: " + correctAnswerIndex);
    }

    // Example usage:
    void Start()
    {
        DisplayRandomQuestion();
    }
}