using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
      
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (Time.timeScale != 0) PauseGame();
            else ResumeGame();
            optionsMenu.SetActive(!optionsMenu.activeSelf);
             
        }
        

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
