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

    public void GOzero()
    {
        SceneManager.LoadScene(0);
    }
    public void GOone()
    {
        SceneManager.LoadScene(1);
    }


     public void GOtwo()
    {
        SceneManager.LoadScene(2);
    }


    public void GOthree()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit ()

    {
        Application.Quit();

    }
}
