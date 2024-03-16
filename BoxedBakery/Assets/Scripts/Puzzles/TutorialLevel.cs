using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class TutorialLevel : MonoBehaviour
{
    public GameObject CenterSpot; 
    public GameObject continueButton; 
    public GameObject Coins; 
    public FilledSpotDetect filledSpot; 
    public string item; 
    public DialogueRunner dialogueRunner;

    // Update is called once per frame
    void Update()
    {
        if(CenterSpot.CompareTag("DropInvalid"))
        {
            item= filledSpot.item;  
            Debug.Log(item); 
            if(item == "Strawberry")
            {
                continueButton.SetActive(true); 
                Coins.SetActive(true); 
                Debug.Log("we did it!"); 
            }
            else 
            {
              //  dialogueRunner.StartDialogue(Start); 
                 Debug.Log("BAX YOU KNOW BETTER"); 
            }
        }
    }
}
