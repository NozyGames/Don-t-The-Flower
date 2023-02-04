using System.Collections;
using System.Collections.Generic;
using UnityEngine;



 


public class SettingsWindow : MonoBehaviour
{
    public GameObject optionsMenus;


    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector2.zero; 
    }

    public void Open()

    {
       {
            optionsMenus.SetActive(true);


        } //transform.LeanScale(Vector2.one, 0.8f); 

    }

    public void Clos()

    {
        
        optionsMenus.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
