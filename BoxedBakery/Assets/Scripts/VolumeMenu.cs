using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeMenu : MonoBehaviour
{
   public GameObject menu; 
    // Update is called once per frame
    public void ToggleMenu()
    {
        menu.gameObject.SetActive(true); 

    }
}
