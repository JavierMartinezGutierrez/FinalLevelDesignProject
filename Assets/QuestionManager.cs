using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // Array to store questions
    public string[] questions;

    // Array to store corresponding correct answers
    public bool[] correctAnswers;

    // Method to get a random question
    public string GetRandomQuestion()
    {
        // Generate a random index within the range of questions array
        int randomIndex = Random.Range(0, questions.Length);

        // Return the question at the random index
        return questions[randomIndex];
    }

    // Method to verify the answer to a question
    public bool VerifyAnswer(string question, bool playerAnswer)
    {
        // Find the index of the question in the array
        int index = System.Array.IndexOf(questions, question);

        // If the index is valid and the player's answer matches the correct answer, return true
        if (index != -1 && index < correctAnswers.Length)
        {
            return correctAnswers[index] == playerAnswer;
        }

        // If the question is not found or the index is out of range, return false
        return false;
    }
}

