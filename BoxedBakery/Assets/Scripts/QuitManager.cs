using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// code inspired from https://www.youtube.com/watch?v=tfzwyNS1LUY 
public class QuitManager : MonoBehaviour
{
   public GameObject menu;
   public GameObject dialogue;
   public GameObject dragController;
   public bool allowmenu; 

    // Update is called once per frame
    void Update()
    {
       if(allowmenu == true){
            if(Input.GetKeyDown(KeyCode.Escape))
            {
            menu.SetActive(true); 
            dialogue.SetActive(false); 
            dragController.SetActive(false); 
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
          dragController.SetActive(true); 
    }

    public void Quitting()
    {
         Application.Quit();
    }
}
