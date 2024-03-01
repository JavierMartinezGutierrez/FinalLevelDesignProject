using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions = new List<Question>();

    private IList<Question> GetQuestions()
    {
        return questions;
    }

    public void DisplayQuestion(int questionIndex)
    {
        Question question = questions[questionIndex];
        Debug.Log(question.questionText);
        foreach (string answer in question.answers)
        {
            Debug.Log(answer);
        }
    }

    public void AnswerQuestion(int questionIndex, int answerIndex)
    {
        Question question = questions[questionIndex];

        if (answerIndex == question.correctAnswerIndex)
        {
            // The answer is correct
            Debug.Log("Correct!");
        }
        else
        {
            // The answer is wrong
            Debug.Log("Wrong!");
        }
    }

    internal void DisplayQuestion(string question)
    {
        throw new NotImplementedException();
    }
}
public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

[System.Serializable]
public class Question
{
    public string questionText;
    public List<string> answers;
    public int correctAnswerIndex;

    public Question(string questionText, List<string> answers, int correctAnswerIndex)
    {
        this.questionText = questionText;
        this.answers = answers;
        this.correctAnswerIndex = correctAnswerIndex;
    }
}
