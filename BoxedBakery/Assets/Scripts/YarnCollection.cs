using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 
using FMOD.Studio; 

[RequireComponent(typeof(CanvasGroup))]
public class YarnCollection : MonoBehaviour
{
//Cameras
    public GameObject CustomerCamera;
    public GameObject PackingCamera;
    public GameObject CustomerOrder; 
    public bool CustomerView; 
    public bool PackingView; 
//Others 
    public GameObject MainMenu;
    public bool hideButton; 
    public InMemoryVariableStorage variableStorage;
    //public AudioManager MusicVolumne; 

//fade in and out 
    public CanvasGroup canvasGroup; 
    public bool FadeIn;
    public bool FadeOut; 
//Characters 
    //Rea
        public GameObject ReaVisual; 
        public GameObject ReaWorried; 
        public GameObject ReaAngry; 
        public GameObject ReaOrder; 
        public GameObject ReaHappy;
        public bool ReaEnabled; 
        public bool ReaHide; 
    //Busy
        public GameObject BusyVisual; 
        public GameObject BusyOrder;
        public GameObject BusyDonutOrder; 
        public GameObject BusyBagelOrder;  
        public GameObject BusyAddOn;  
        public bool BusyEnabled;
        public GameObject BusyFour; 
        public GameObject BusyCircle; 
        public bool BusyHide;
        public GameObject Bagels; 
        public GameObject Donuts; 
        public GameObject BackupDonuts; 
        public bool BusyNoOrder; 
    //Lars
        public bool Lars;
    //Kid & Dog 
        public GameObject KidVisual; 
        public GameObject KidTailVisual; 
        public GameObject KidOrder;   
        public bool KidEnabled;
        public bool KidTail;
        public bool KidHide;
//Tipping
    //Rea
        public bool ReaTip; 
        public bool Tip; 
        public bool ReaBigTip; 
        public bool BigTip; 
    //Busy 
        public bool BusyTip; 
        public bool BTip; 
        public bool BusyBigTip; 
        public bool BBigTip; 
    // Kid 
        public bool KidTip;
        public bool KTip; 
        public bool KidBigTip;
        public bool KBigTip; 
//Puzzles
    public GameObject TutorialPuzzle; 
    public bool TutorialP;
    public GameObject Puzzle1; 
    public bool P1;
    public bool Puzzle1R; 
    public GameObject Puzzle2; 
    public bool P2;
//Other 
    public GameObject Day1End; 
    public bool DoorSound; 
    public bool PhoneSound; 
    public float audioLevel; 

    [SerializeField] private string parameterName; 
    [SerializeField] private float parameterValue; 

    // Update is called once per frame
    void Awake()
    {
        audioLevel = AudioManager.instance.musicVolume; 
    }
    void Update()
    {
        //MainMenu Trigger 
        variableStorage.SetValue("$MainMenu", MainMenu);
        //Camera moving
        variableStorage.SetValue("$CustomerView", CustomerView);
        variableStorage.SetValue("$PackingView", PackingView);
        //Camera fading 
        variableStorage.SetValue("$FadeIn", FadeIn);
        variableStorage.SetValue("$FadeOut", FadeOut);
        //Characters 
        //Rea
        variableStorage.SetValue("$ReaEnabled", ReaEnabled);
        variableStorage.SetValue("$ReaHide", ReaHide);
        variableStorage.SetValue("$ReaOrder", ReaOrder);
        variableStorage.SetValue("$ReaWorried", ReaWorried);
        variableStorage.SetValue("$ReaAngry", ReaAngry);
        variableStorage.SetValue("$ReaHappy", ReaHappy);
        //Busy
        variableStorage.SetValue("$BusyEnabled", BusyEnabled);
        variableStorage.SetValue("$BusyHide", BusyHide);
        variableStorage.SetValue("$BusyFour", BusyFour);
        variableStorage.SetValue("$BusyCircle", BusyCircle);
        variableStorage.SetValue("$BusyOrder", BusyOrder);
        variableStorage.SetValue("$BusyDonutOrder", BusyDonutOrder);
        variableStorage.SetValue("$BusyBagelOrder", BusyBagelOrder);
        variableStorage.SetValue("$BusyNoOrder", BusyNoOrder);
        //Lars 
        variableStorage.SetValue("$Lars", Lars);
        // Kid & Dog 
        variableStorage.SetValue("$KidEnabled", KidEnabled);
        variableStorage.SetValue("$KidTail", KidTail);
        variableStorage.SetValue("$KidHide", KidHide);
        //tipping
        variableStorage.SetValue("$ReaTip", ReaTip);
        variableStorage.SetValue("$ReaBigTip", ReaBigTip);
        variableStorage.SetValue("$BusyTip", BusyTip);
        variableStorage.SetValue("$BusyBigTip", BusyBigTip);
        variableStorage.SetValue("$KidTip", KidTip);
        variableStorage.SetValue("$KidBigTip", KidBigTip);
        //puzzles
        variableStorage.SetValue("$TutorialPuzzle", TutorialP);
        variableStorage.SetValue("$Puzzle1Remove", Puzzle1R);
        variableStorage.SetValue("$Puzzle1", P1);
        variableStorage.SetValue("$Puzzle2", P2);
        //Other 
        variableStorage.SetValue("$hideButton", hideButton); 
        variableStorage.SetValue("$Day1End", Day1End); 
        //sounds
        variableStorage.SetValue("$DoorSound", DoorSound); 
        variableStorage.SetValue("$PhoneSound", PhoneSound); 
    }
    [YarnCommand("MainMenu")]
    public void CallMainMenu()
    {
        //AudioManager.instance.PleaseStop(); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); 
    }
//Camera Changing Commands 
    [YarnCommand("PackingView")]
    public void CamToPack()
    {
        PackingCamera.SetActive(true);
        CustomerCamera.SetActive(false);
        AudioManager.instance.musicVolume =  0.3f;  
    }
    
    [YarnCommand("CustomerView")]
    public void CamToCustomer()
    {
        CustomerCamera.SetActive(true);
        PackingCamera.SetActive(false);
        AudioManager.instance.musicVolume =  audioLevel;  
        ReaOrder.SetActive(false);
        BusyOrder.SetActive(false);
        BusyBagelOrder.SetActive(false);
        BusyDonutOrder.SetActive(false);
        KidOrder.SetActive(false);
    }
    
//Fades Commands 
    [YarnCommand("FadeIn")]
    public IEnumerator FadeInTransition ()
    {
        yield return StartCoroutine(Fade(1, 0, 1.5f));
    }
    
    [YarnCommand("FadeOut")]
    public IEnumerator FadeOutTransition ()
    {
        yield return StartCoroutine(Fade(0, 1, 1.5f));
    }
    public IEnumerator Fade(float from, float to, float time) 
    {
        canvasGroup.alpha = from;
        float elapsed = 0f;
        while (elapsed < time) 
        {
            var factor = elapsed / time;
            canvasGroup.alpha = Mathf.Lerp(from, to, factor);
            yield return null;
            elapsed += Time.deltaTime;
        }
        canvasGroup.alpha = to;
    }

//Rea Character Commands
    [YarnCommand("ReaEnabled")]
    public void EnableRea(){
        ReaVisual.SetActive(true);
        ReaHappy.SetActive(false);
        ReaAngry.SetActive(false);
        ReaWorried.SetActive(false); }
    
    [YarnCommand("ReaHide")]
    public void HideRea(){
        ReaVisual.SetActive(false);
        ReaHappy.SetActive(false);
        ReaAngry.SetActive(false);
        ReaWorried.SetActive(false);
    }
    [YarnCommand("ReaAngry")]
    public void ReaIsAngry(){
        ReaAngry.SetActive(true);
        ReaHappy.SetActive(false);
        ReaVisual.SetActive(false);
        ReaWorried.SetActive(false); }
    
    [YarnCommand("ReaWorried")]
    public void ReaIsWorried(){
        ReaWorried.SetActive(true);
        ReaHappy.SetActive(false);
        ReaAngry.SetActive(false);
        ReaVisual.SetActive(false); }
    
    [YarnCommand("ReaHappy")]
    public void ReaIsHappy(){
        ReaHappy.SetActive(true);
        ReaWorried.SetActive(false);
        ReaAngry.SetActive(false);
        ReaVisual.SetActive(false); }
    
    [YarnCommand("ReaOrder")]
    public void DisplayReaOrder(){ReaOrder.SetActive(true);}
    
    [YarnCommand("ReaTip")]
    public void ReaTipped(){Tip = true; }
    
    [YarnCommand("ReaBigTip")]
    public void ReaTippedBig(){BigTip = true;}

//Business Character Commands 
    [YarnCommand("BusyEnabled")]
    public void EnableBusy(){
        BusyVisual.SetActive(true);
        BusyFour.SetActive(false); 
        BusyCircle.SetActive(false); }

    [YarnCommand("BusyHide")]
    public void HideBusy(){
         BusyVisual.SetActive(false);
        BusyFour.SetActive(false); 
        BusyCircle.SetActive(false);}
    
    [YarnCommand("BusyFour")]
    public void EnableFour(){
        BusyFour.SetActive(true); 
        BusyCircle.SetActive(false);}   
    
    [YarnCommand("BusyCircle")]
    public void EnableCircle(){
        BusyCircle.SetActive(true);
        BusyFour.SetActive(false);}
    [YarnCommand("BusyOrder")]
    public void DisplayBusyOrder(){
        BusyOrder.SetActive(true); 
        BusyAddOn.SetActive(true);
        Donuts.SetActive(true);}
    [YarnCommand("BusyNoOrder")]
    public void DisplayBusyFood(){
        Bagels.SetActive(true);
        BackupDonuts.SetActive(true);}  
    [YarnCommand("BusyDonutOrder")]
    public void DisplayDonutOrder(){
        BusyDonutOrder.SetActive(true);
        Donuts.SetActive(true);
        }
    [YarnCommand("BusyBagelOrder")]
    public void DisplayBagelOrder(){BusyBagelOrder.SetActive(true);
        Bagels.SetActive(true);}

    [YarnCommand("BusyTip")]
    public void BusyTipped(){BTip = true; }
    
    [YarnCommand("BusyBigTip")]
    public void BusyTippedBig(){BBigTip = true;}
//Lars 
    [YarnCommand("Lars")]
    public void LarsTriggered(){Lars = true;}
//Kid & Dog Character Commands 
    [YarnCommand("KidEnabled")]
    public void EnableKid(){
        KidVisual.SetActive(true);
        KidTailVisual.SetActive(false);
    }
    [YarnCommand("KidTail")]
    public void EnableKidTail(){
        KidVisual.SetActive(false);
        KidTailVisual.SetActive(true);
        Debug.Log("Tail wags"); 
    }
    [YarnCommand("KidHide")]
    public void HideKid(){
        KidVisual.SetActive(false);
        KidTailVisual.SetActive(false);}
    
    [YarnCommand("KidOrder")]
    public void DisplayKidOrder(){
        KidOrder.SetActive(true);} 

    [YarnCommand("KidTip")]
    public void KidTipped(){KTip = true; }
    
    [YarnCommand("KidBigTip")]
    public void KidTippedBig(){KBigTip = true;}
//Puzzle Commands 
    [YarnCommand("TutorialPuzzle")]
    public void DisablePuzzleT()
    {
        TutorialPuzzle.SetActive(false); 
    }
     [YarnCommand("Puzzle1")]
    public void EnablePuzzle1()
    {
        Puzzle1.SetActive(true);
    }
    [YarnCommand("Puzzle1Remove")]
    public void DisablePuzzle1()
    {
       Puzzle1.SetActive(false); 
    }
    [YarnCommand("Puzzle2")]
    public void EnablePuzzle2()
    {
        Puzzle2.SetActive(true);
    }
    [YarnCommand("Day1End")]
     public void EnableDay1End()
    {
        Day1End.SetActive(true);
    }

    [YarnCommand("hideButton")]
    public void ToggleButton()
    {
        if(hideButton == false)
        {
            hideButton = true;
        }
        else
        { hideButton = false; }
    }
    
    //Sounds
    [YarnCommand("DoorSound")]
    public void PlayDoorSound()
    {
         AudioManager.instance.PlayOneShot(FMODEvents.instance.DoorSound, this.transform.position);
    }
    [YarnCommand("PhoneSound")]
    public void PlayPhoneSound()
    {
         AudioManager.instance.PlayOneShot(FMODEvents.instance.PhoneSound, this.transform.position);
    }
}
