using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class PuzzleOne : MonoBehaviour
{
    [SerializeField] private string BusyTooBusy;
    [SerializeField] private string BusyCorrectOrder;
    [SerializeField] private string BusyIncorrectOrder;
   
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
            public bool PackedCheck1; 
     
    //Player Feedback
        public GameObject Coins; 
        public GameObject LidOpen; 
        public GameObject LidClosed;
        public DialogueRunner dialogueRunner;
        public GameObject continueButton;
        public YarnCollection storyVars;
//Money
 
    void Start()
   {
    itemsChecked = false; 
    PackedCheck1 = false; 
   }
    
    
    void Update()
    {
        if( topLeft.CompareTag("DropInvalid") && bottomLeft.CompareTag("DropInvalid") && topRight.CompareTag("DropInvalid") && bottomRight.CompareTag("DropInvalid"))
        {
            itemTopLeft = filledTopLeft.item;
            itemBottomLeft = filledBottomLeft.item;
            itemTopRight = filledTopRight.item;
            itemBottomRight = filledBottomRight.item;
            if(PackedCheck1 == false)
            {
            continueButton.SetActive(true);
            }
        }
        else
        {
            continueButton.SetActive(false); 
        }
    }

    public void checkIfItemisValid()
    {
        if(itemTopLeft == "donut" && itemBottomLeft == "donut" && itemTopRight == "donut" && itemBottomRight == "donut") 
        { 
            PackedCheck1 = true; 
            Lids();  
            dialogueRunner.StartDialogue(BusyCorrectOrder);
        }
        else 
        {
            if(itemsChecked == false)
            {
                dialogueRunner.StartDialogue(BusyTooBusy); 
                itemsChecked = true;
                continueButton.SetActive(false); 
            }
            else 
            {
                Lids();   
                PackedCheck1 = true; 
                dialogueRunner.StartDialogue(BusyIncorrectOrder);
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
