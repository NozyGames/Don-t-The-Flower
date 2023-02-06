using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class SettingsWindow : MonoBehaviour
{

    public GameObject optionsMenu;

    // Start is called before the first frame update
    private void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()

    {
        optionsMenu.SetActive(true);

    }

    public void Clos()

    {
        optionsMenu.SetActive(false);

    }
    // Update is called once per frame
    void Update()
    {

    }
}
