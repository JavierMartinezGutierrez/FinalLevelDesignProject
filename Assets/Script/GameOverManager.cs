using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel;

    void Start()
    {
        // Hide the game over panel when the scene starts
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverPanel()
    {
        // Show the game over panel
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }
}