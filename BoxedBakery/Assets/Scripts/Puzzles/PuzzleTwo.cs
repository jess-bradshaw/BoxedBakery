using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 
// Code roughly inspired by: https://www.youtube.com/watch?v=I17uqTxbWK0 & https://www.youtube.com/watch?v=FdxvTcHJiA8
public class PuzzleTwo : MonoBehaviour
{
  [SerializeField] private string KidCorrection;
    [SerializeField] private string KidCorrectOrder;
    [SerializeField] private string KidIncorrectOrder;
   
    //Puzzle Variables 
        //Spots
            public GameObject topLeft; 
            public FilledSpotDetect filledTopLeft; 
            public GameObject bottomLeft; 
            public FilledSpotDetect filledBottomLeft; 
            public GameObject topRight; 
            public FilledSpotDetect filledTopRight; 
            public GameObject bottomRight; 
            public FilledSpotDetect filledBottomRight; 

        //Items
            public string itemTopLeft; 
            public string itemBottomLeft;
            public string itemTopRight; 
            public string itemBottomRight; 
        //Checks
            public bool itemsChecked; 
            public bool PackedCheck;
            public YarnCollection dialogue;

    //Player Feedback
    public GameObject Coins; 
    public GameObject LidOpen; 
    public GameObject LidClosed;
    public DialogueRunner dialogueRunner;
    public GameObject continueButton;
    public YarnCollection storyVars;
//Money
    public GameObject tip;
    public GameObject bigTip; 
    void Start()
   {
    itemsChecked = false; 
    PackedCheck = false; 
   }
    
    
    void Update()
    {
        if( topLeft.CompareTag("DropInvalid") && bottomLeft.CompareTag("DropInvalid") && topRight.CompareTag("DropInvalid") && bottomRight.CompareTag("DropInvalid"))
        {
            itemTopLeft = filledTopLeft.item;
            itemBottomLeft = filledBottomLeft.item;
            itemTopRight = filledTopRight.item;
            itemBottomRight = filledBottomRight.item;
            if(PackedCheck == false)
            {
                if (dialogue.hideButton == false)
                {
                    continueButton.SetActive(true);
                }
            }
        }
        else
        {
            continueButton.SetActive(false); 
        }
    }

    public void checkIfItemisValid()
    {
        if((itemTopLeft == "Chocolate" && itemBottomLeft == "NonChocolate" && itemTopRight == "NonChocolate" && itemBottomRight == "AvoidChocolate") || 
            (itemTopLeft == "NonChocolate" && itemBottomLeft == "Chocolate" && itemTopRight == "AvoidChocolate" && itemBottomRight == "NonChocolate") ||
            (itemTopLeft == "NonChocolate" && itemBottomLeft == "AvoidChocolate" && itemTopRight == "Chocolate" && itemBottomRight == "NonChocolate") || 
            (itemTopLeft == "AvoidChocolate" && itemBottomLeft == "NonChocolate" && itemTopRight == "NonChocolate" && itemBottomRight == "Chocolate")) 
        { 
             if (storyVars.KidTip== true) //Checks if the person was tipped or not. 
            { 
                tip.SetActive(true); 
                AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinTipped, this.transform.position); 
            }
            if (storyVars.KidBigTip== true) //checks if the person was super nice and tipped even more. 
            { 
                bigTip.SetActive(true);  
            }
            PackedCheck = true; 
            Lids();  
            dialogueRunner.StartDialogue(KidCorrectOrder);
        }
        else 
        {
             
            if(itemsChecked == false)
            {
                dialogueRunner.StartDialogue(KidCorrection); 
                itemsChecked = true;
                continueButton.SetActive(false); 
            }
            else 
            {
                Lids();   
                PackedCheck = true; 
                dialogueRunner.StartDialogue(KidIncorrectOrder);
            }
            
        }
    }
     public void Lids()
    {
        LidClosed.SetActive(true);
        LidOpen.SetActive(false); 
        Coins.SetActive(true);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinPaid, this.transform.position);
        continueButton.SetActive(false);   
    }
}
