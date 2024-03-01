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
   

    public int PlayerScore
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public int ComputerPlayerScore
    {
        get { return computerPlayerScore; }
        set { computerPlayerScore = value; }
    }

    public int SecondPlayerScore
    {
        get { return secondPlayerScore; }
        set { secondPlayerScore = value; }
    }

    


    public void Retry()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        // Load the menu scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}