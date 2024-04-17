using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsScreenManager : MonoBehaviour

{
    public Text winnerText;
    public Text playerScoreText;
    public Text computerPlayerScoreText;
    public Text secondPlayerScoreText;
    public int playerScore = 0;
    public int computerPlayerScore = 0;
    public int secondPlayerScore = 0;

    public Button nextLevelButton; // Reference to the next level button

    public void Retry()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }

    public void LoadNextLevel()
    {
        // Implement logic to determine the next level to load
        // For example:
        // SceneManager.LoadScene("Level2");
    }

    private void Start()
    {
        // Ensure the next level button is disabled at the start
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(LoadNextLevel);
            nextLevelButton.gameObject.SetActive(false);
        }
    }

    // Other methods for updating UI and managing scores...
}