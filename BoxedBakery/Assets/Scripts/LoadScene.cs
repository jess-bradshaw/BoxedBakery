using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel1()
    {
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
