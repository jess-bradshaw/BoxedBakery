using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class TutorialLevel : MonoBehaviour
{
    // internal properties exposed to editor
    [SerializeField] private string BaxKnowsBetter;
    [SerializeField] private string CorrectOrder;
    [SerializeField] private string InCorrectOrder;
    public GameObject CenterSpot; 
    public GameObject continueButton; 
    public GameObject Coins; 
     public GameObject LidOpen; 
      public GameObject LidClosed; 
    public FilledSpotDetect filledSpot; 
    public string item; 
    public DialogueRunner dialogueRunner;
    public bool itemChecked; 
    public bool PackedCheck; 
    public YarnCollection storyVars;
    public GameObject tip;
    public GameObject bigTip; 
    public int money; 

    // Update is called once per frame
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
        if(item == "Strawberry")
        { 
            Coins.SetActive(true); 
             if (storyVars.Tip== true)
            { 
                tip.SetActive(true); 
                AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinTipped, this.transform.position); 
            }
            if (storyVars.BigTip== true)
            { 
                bigTip.SetActive(true);  
            }
            PackedCheck = true; 
            continueButton.SetActive(false); 
            LidClosed.SetActive(true);
            LidOpen.SetActive(false); 
            dialogueRunner.StartDialogue(CorrectOrder);
            
        }
        else 
        {
            if(itemChecked == false)
            {
                dialogueRunner.StartDialogue(BaxKnowsBetter); 
                itemChecked = true;
            }
            else 
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinPaid, this.transform.position); 
                Coins.SetActive(true); 
                LidClosed.SetActive(true);
                LidOpen.SetActive(false);  
                PackedCheck = true; 
                dialogueRunner.StartDialogue(InCorrectOrder);
                continueButton.SetActive(false); 
            }
        }
    }
}
