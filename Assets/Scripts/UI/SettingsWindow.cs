using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsWindow : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector2.zero; 
    }

    public void Open()

    {
        transform.LeanScale(Vector2.one, 0.8f); 

    }

    public void Clos()

    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack(); 

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
