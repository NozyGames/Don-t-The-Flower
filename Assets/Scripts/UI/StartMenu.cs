using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
    Scene ActiveScene;


    public void Start()
    {
        ActiveScene = SceneManager.GetActiveScene(); 



    }



    public void StartGame()
    {
        SceneManager.LoadScene(ActiveScene.buildIndex + 1);

    }

    public void Menue()
    {
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void Credit()
    {
        SceneManager.LoadScene(3);
    }
}
