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
    public YarnCollection storyVars;
    public GameObject tip;
    public GameObject bigTip; 
    public int money; 

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
            //Debug.Log(item); 
             
            if(item == "Strawberry")
            {
                continueButton.SetActive(true); 
                Coins.SetActive(true); 
                if (storyVars.Tip== true)
                { 
                    tip.SetActive(true); 
                }
                 if (storyVars.BigTip== true)
                { 
                    bigTip.SetActive(true); 
                }
            }
            else 
            {
              if(itemChecked == false)
              {
              dialogueRunner.StartDialogue(conversationStartNode); 
                // Debug.Log("BAX YOU KNOW BETTER"); 
                 itemChecked = true;
              }
              else 
              {
               continueButton.SetActive(true); 
               Coins.SetActive(true); 
                //Debug.Log("We skipping"); 
              }
            }
        }
    }
}
