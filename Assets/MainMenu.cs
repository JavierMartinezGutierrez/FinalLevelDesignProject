using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void OnlineGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2, LoadSceneMode.Additive);

    }

    public void Options()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3, LoadSceneMode.Additive);
    }

    public void Friends()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4, LoadSceneMode.Additive);
    }
    public void Shop()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5, LoadSceneMode.Additive);
    }
    public void Trophies()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6, LoadSceneMode.Additive);
    }
    public void TeamCollection()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7, LoadSceneMode.Additive);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
