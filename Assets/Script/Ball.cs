using UnityEngine;

public class Ball : MonoBehaviour
{
    public QuestionManager questionManager;
    public Scoreboard scoreboard;
    public float bounceForce = 10f;
    public string[] questions;
    public string[] answers;
    private bool ballCaught;

    private string GetRandomQuestion()
    {
        int index = UnityEngine.Random.Range(0, questions.Length);
        return questions[index];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Display a random question when the ball drops
            string question = GetRandomQuestion();
            questionManager.DisplayQuestion(question);
        }
        else if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI") || collision.gameObject.CompareTag("Player2"))
        {
            string playerAnswer = "Your answer here";
            string correctAnswer = "0,99";
            bool answerIsCorrect = CheckAnswer(playerAnswer, correctAnswer);
            


            if (answerIsCorrect)
            {
                // Ball bounces back to the respective player
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.velocity = (collision.gameObject.transform.position - transform.position).normalized * bounceForce;

                // Update scoreboard if needed
                if (collision.gameObject.CompareTag("Player"))
                {
                    scoreboard.AddPlayerPoints();
                }
                else if (collision.gameObject.CompareTag("AI"))
                {
                    scoreboard.AddAIPoints();
                }
                else if (collision.gameObject.CompareTag("Player2"))
                {
                    scoreboard.AddPlayer2Points();
                }
            }
            else
            {
                // Ball is dead if the answer is wrong
                ballCaught = false;
            }
        }
    }

    private bool CheckAnswer(string playerAnswer, string correctAnswer)
    {
        // Implement logic for checking answers here
        throw new System.NotImplementedException();
    }
}



