using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class TutorialLevel : MonoBehaviour
{
    // internal properties exposed to editor
    [SerializeField] private string conversationStartNode;

    public GameObject CenterSpot; 
    public GameObject continueButton; 
    public GameObject Coins; 
    public FilledSpotDetect filledSpot; 
    public string item; 
    public DialogueRunner dialogueRunner;
    public bool itemChecked; 

    // Update is called once per frame
   void Start()
   {
    itemChecked = false; 
   }
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
              if(itemChecked == false)
              {
              dialogueRunner.StartDialogue(conversationStartNode); 
                 Debug.Log("BAX YOU KNOW BETTER"); 
                 itemChecked = true;
              }
              else 
              {
                Debug.Log("We skipping"); 
              }
            }
        }
    }
}
