using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public GameObject player;
    public GameObject questionPanel;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player && questionPanel != null)
        {
            // Generate a random question and answer for demonstration
            string question = "What is 2 + 2?";
            string answer = "4";
            DisplayQuestion(question, answer);
        }
    }

    private void DisplayQuestion(string question, string answer)
    {
        Debug.Log("Displaying question...");
        if (questionPanel != null)
        {
            // Get the text components of the question panel
            Text questionText = questionPanel.GetComponentInChildren<Text>();
            Text answerText = questionPanel.transform.Find("AnswerText").GetComponent<Text>();

            if (questionText == null)
                Debug.LogError("Question text component not found!");
            if (answerText == null)
                Debug.LogError("Answer text component not found!");

            // Set the question and answer text
            if (questionText != null)
                questionText.text = question;

            if (answerText != null)
                answerText.text = answer;

            // Show the question panel
            questionPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Question panel reference is not set!");
        }
    }
    public float speed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; // Initial movement in forward direction
    }

    void FixedUpdate()
    {
        // Prevent bouncing off walls by adjusting velocity
        Vector3 vel = rb.velocity;
        vel.y = 0f; // Ensure no vertical movement
        rb.velocity = vel;
    }
}
