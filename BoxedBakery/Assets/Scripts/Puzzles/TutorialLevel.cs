using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 
// Code roughly inspired by: https://www.youtube.com/watch?v=I17uqTxbWK0 & https://www.youtube.com/watch?v=FdxvTcHJiA8
public class TutorialLevel : MonoBehaviour
{
    // internal properties exposed to editor
    [SerializeField] private string BaxKnowsBetter;
    [SerializeField] private string CorrectOrder;
    [SerializeField] private string InCorrectOrder;
    
    //Puzzle Variables
        //Spot
            public GameObject CenterSpot; 
            public FilledSpotDetect filledSpot; 
        //Item
            public string item; 
        //Checks
            public bool itemChecked; 
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
        public GameObject fishMoney; 
        //public int money; 

   void Start()
   {
    itemChecked = false; 
    PackedCheck = false; 
   }
    void Update()
    {
        if(CenterSpot.CompareTag("DropInvalid"))
        {
            item = filledSpot.item;  
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
        if(item == "Strawberry")
        { 
            Coins.SetActive(true); 
             if (storyVars.Tip== true) //Checks if the person was tipped or not. 
            { 
                tip.SetActive(true); 
                AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinTipped, this.transform.position); 
            }
            if (storyVars.BigTip== true) //checks if the person was super nice and tipped even more. 
            { 
                bigTip.SetActive(true);  
            }
            PackedCheck = true; 
            Lids(); 
            dialogueRunner.StartDialogue(CorrectOrder);
            
        }
        else 
        {
            if(itemChecked == false)
            {
                dialogueRunner.StartDialogue(BaxKnowsBetter); 
                itemChecked = true;
                continueButton.SetActive(false); 
            }
            else 
            { 
                Lids();  
                PackedCheck = true; 
                dialogueRunner.StartDialogue(InCorrectOrder);
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
