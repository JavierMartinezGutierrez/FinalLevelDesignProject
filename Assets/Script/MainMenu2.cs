using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu2: MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DodgeBall");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit(); 

    }
    public void PauseGame()
    {
        SceneManager.LoadScene("Menu");
    }
}

