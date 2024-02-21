using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneManager : MonoBehaviour
{
    public void ReturnToMenu()
    {
        // Load the menu scene
        SceneManager.LoadScene("Menu");
    }
}
