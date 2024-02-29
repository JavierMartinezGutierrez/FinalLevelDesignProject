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
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame()
    {
        SceneManager.LoadScene("Menu");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("Menu");
    }

}

