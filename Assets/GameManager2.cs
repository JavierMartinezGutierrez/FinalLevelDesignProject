using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using System.Drawing;

public class GameManager : MonoBehaviour
{
    // Reference to the ScoreManager script
    public ScoreManager scoreManager;

    void Start()
    {
        // Find the ScoreManager script in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Example method to handle when Player 1 hits the ball
    public void Player1HitBall()
    {
        // Call the Player1HitBall method in ScoreManager
        scoreManager.Player1HitBall();
    }

    // Example method to handle when Player 2 hits the ball
    public void Player2HitBall()
    {
        // Call the Player2HitBall method in ScoreManager
        scoreManager.Player1HitBall();
    }

    // Example method to handle when a question is answered correctly
    // Example method to handle when a question is answered correctly
    public void QuestionAnsweredCorrectly(int playerNumber)
    {
        // Call the AnswerQuestionCorrectly method in ScoreManager for the corresponding player
        if (playerNumber == 1)
            scoreManager.AnswerQuestionCorrectly(1, 1); // Providing 1 point for a correct answer
        else if (playerNumber == 2)
            scoreManager.AnswerQuestionCorrectly(2, 1); // Providing 1 point for a correct answer
    }

    // Example method to handle when a question is answered incorrectly
    public void QuestionAnsweredIncorrectly(int playerNumber)
    {
        // Call the AnswerQuestionIncorrectly method in ScoreManager for the corresponding player
        if (playerNumber == 1)
            scoreManager.AnswerQuestionIncorrectly(1, 1); // Deducting 1 point for an incorrect answer
        else if (playerNumber == 2)
            scoreManager.AnswerQuestionIncorrectly(2, 1); // Deducting 1 point for an incorrect answer
    }
}