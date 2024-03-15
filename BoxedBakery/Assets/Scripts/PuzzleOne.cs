using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleOne : MonoBehaviour
{
    public GameObject topLeft; 
    public GameObject bottomLeft; 
    public GameObject topRight; 
    public GameObject bottomRight; 
    public GameObject continueButton; 
    public GameObject Coins; 

    // Update is called once per frame
    void Update()
    {
        if( topLeft.CompareTag("DropInvalid") && bottomLeft.CompareTag("DropInvalid") && topRight.CompareTag("DropInvalid") && bottomRight.CompareTag("DropInvalid"))
        {
            continueButton.SetActive(true); 
            Coins.SetActive(true); 
            Debug.Log("we did it!"); 
        }
    }
}
