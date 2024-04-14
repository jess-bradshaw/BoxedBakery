using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using FMOD.Studio; 
// Audio focused code from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class LoadScene : MonoBehaviour
{
    public GameObject LidClosed; 
    public GameObject LidOpen; 


    public void LoadLevel1()
    {
       AudioManager.instance.PlayOneShot(FMODEvents.instance.ContinueButton, this.transform.position);
        LidClosed.SetActive(true);
        LidOpen.SetActive(false); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_One"); 
    }

      public void LoadLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level_Two"); 
    }
       public void LoadMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); 
       
    }
}
