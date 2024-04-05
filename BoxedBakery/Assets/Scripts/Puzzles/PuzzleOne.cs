using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class PuzzleOne : MonoBehaviour
{
    [SerializeField] private string BusyTooBusy;
    [SerializeField] private string BusyCorrectOrder;
    [SerializeField] private string BusyIncorrectOrder;
    public GameObject topLeft; 
    public GameObject bottomLeft; 
    public GameObject topRight; 
    public GameObject bottomRight; 
    public GameObject continueButton; 
    public GameObject Coins; 
    public GameObject LidOpen; 
    public GameObject LidClosed;
    public DialogueRunner dialogueRunner;
    public YarnCollection storyVars;

    public bool itemChecked; 
    public bool PackedCheck1; 
    void Start()
   {
    itemChecked = false; 
    PackedCheck1 = false; 
   }
    
    
    void Update()
    {
        if( topLeft.CompareTag("DropInvalid") && bottomLeft.CompareTag("DropInvalid") && topRight.CompareTag("DropInvalid") && bottomRight.CompareTag("DropInvalid"))
        {
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
        if(PackedCheck1 == false) //fix this. 
        { 
            Coins.SetActive(true); 
            PackedCheck1 = true; 
            continueButton.SetActive(false); 
            LidClosed.SetActive(true);
            LidOpen.SetActive(false); 
            dialogueRunner.StartDialogue(BusyCorrectOrder);
            
        }
        else 
        {
            if(itemChecked == false)
            {
                dialogueRunner.StartDialogue(BusyTooBusy); 
                itemChecked = true;
            }
            else 
            {
                AudioManager.instance.PlayOneShot(FMODEvents.instance.CoinPaid, this.transform.position); 
                Coins.SetActive(true); 
                LidClosed.SetActive(true);
                LidOpen.SetActive(false);  
                PackedCheck1 = true; 
                dialogueRunner.StartDialogue(BusyIncorrectOrder);
                continueButton.SetActive(false); 
            }
        }
    }
}
