using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour
{
   public GameObject menu;
   public GameObject dialogue;
   public bool allowmenu; 

    // Update is called once per frame
    void Update()
    {
       if(allowmenu == true){
            if(Input.GetKeyDown(KeyCode.Escape))
            {
            menu.SetActive(true); 
            dialogue.SetActive(false); 
            Time.timeScale = 0f; 
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
            Application.Quit();
            }
        }
    }

    public void Resume()
    {
          menu.SetActive(false); 
          Time.timeScale = 1f; 
          dialogue.SetActive(true); 
    }

    public void Quitting()
    {
         Application.Quit();
    }
}
