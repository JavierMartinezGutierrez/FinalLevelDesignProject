using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MultipleChoice : MonoBehaviour
{
    public GameObject popupWindow;
    public Text questionText;
    public Button[] answerButtons;

    private List<Question> questions = new List<Question>();
    private int currentQuestionIndex = -1;

    [System.Serializable]
    public class Question
    {
        public string question;
        public string[] answers;
        public int correctAnswerIndex;
    }

    void Start()
    {
        // Initialize questions here
        // Example:
        questions.Add(new Question
        {
            question = "What is the capital of France?",
            answers = new string[] { "Paris", "London", "Berlin", "Rome" },
            correctAnswerIndex = 0
        });
    }

    public void ShowRandomQuestion()
    {
        currentQuestionIndex = Random.Range(0, questions.Count);
        Question currentQuestion = questions[currentQuestionIndex];
        questionText.text = currentQuestion.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Set the text of answer buttons
            answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.answers[i];
        }

        popupWindow.SetActive(true);
    }

    public void CheckAnswer(int answerIndex)
    {
        if (currentQuestionIndex != -1)
        {
            if (answerIndex == questions[currentQuestionIndex].correctAnswerIndex)
            {
                Debug.Log("Correct!");
                // Here, you can access the ScoreManager to award points for a correct answer
                ScoreManager.instance.IncreaseScore(1); // Example: Award 1 point for a correct answer
            }
            else
            {
                Debug.Log("Incorrect!");
            }
            popupWindow.SetActive(false);
        }
    }

    // Method to handle when the player gets hit with the ball
    public void PlayerHit()
    {
        // Implement your logic for what happens when the player gets hit with the ball
        // For example, you can reduce the player's health, deduct points, or trigger other events
        Debug.Log("Player got hit with the ball!");

        // Here, you can access the ScoreManager to deduct points
        ScoreManager.instance.DecreaseScore(1); // Example: Deduct 1 point from the player who got hit

        // You can also trigger other events, such as playing a sound effect, showing an animation, etc.
    }
}
