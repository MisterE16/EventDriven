using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public GameObject menuCanvas;
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            menuCanvas.SetActive(!menuCanvas.activeSelf);
        }
    }
}
