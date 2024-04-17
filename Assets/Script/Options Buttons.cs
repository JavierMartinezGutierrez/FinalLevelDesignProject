using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class OptionsButtons : MonoBehaviour
{
    public Slider volumeSlider;
    public Button backButton;
    public Button easyButton;
    public Button hardButton;

    private float currentVolume = 0.5f; // Initial volume value
    private Difficulty currentDifficulty = Difficulty.Easy; // Initial difficulty value

    void Start()
    {
        // Set initial values
        volumeSlider.value = currentVolume;
        UpdateDifficultyButtons();

        // Assign functions to UI element events
        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        backButton.onClick.AddListener(ReturnToMainMenu);
        easyButton.onClick.AddListener(() => SetDifficulty(Difficulty.Easy));
        hardButton.onClick.AddListener(() => SetDifficulty(Difficulty.Hard));
    }

    void UpdateVolume(float value)
    {
        // Update volume and apply to the game
        currentVolume = value;
        AudioListener.volume = currentVolume;
    }

    void SetDifficulty(Difficulty difficulty)
    {
        // Set the difficulty and update UI
        currentDifficulty = difficulty;
        UpdateDifficultyButtons();
    }

    void UpdateDifficultyButtons()
    {
        // Update UI based on the current difficulty
        ColorBlock easyColors = easyButton.colors;
        ColorBlock hardColors = hardButton.colors;

        easyColors.normalColor = (currentDifficulty == Difficulty.Easy) ? Color.green : Color.white;
        hardColors.normalColor = (currentDifficulty == Difficulty.Hard) ? Color.green : Color.white;

        easyButton.colors = easyColors;
        hardButton.colors = hardColors;
    }

    void ReturnToMainMenu()
    {
        // Implement code to return to the main menu
        Debug.Log("Returning to main menu");
        // Add your code to switch scenes or handle main menu navigation.
        SceneManager.LoadScene("MainMenu"); // Replace "MainMenu" with the name of your main menu scene
    }
  
}

public enum Difficulty
{
    Easy,
    Hard
}
