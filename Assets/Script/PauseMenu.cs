using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;

    void Start()
    {
        // Hide the pause menu panel when the scene starts
        pauseMenuPanel.SetActive(false);
    }

    public void TogglePauseMenu()
    {
        // Toggle the visibility of the pause menu panel
        pauseMenuPanel.SetActive(!pauseMenuPanel.activeSelf);

        // Pause or unpause the game
        Time.timeScale = pauseMenuPanel.activeSelf ? 0 : 1;
    }

    public void ReturnToDodgeballLevel()
    {
        // Load the Dodgeball level
        SceneManager.LoadScene("DodgeballLevel");
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}