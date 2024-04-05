using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

[RequireComponent(typeof(CanvasGroup))]
public class YarnCollection : MonoBehaviour
{
    //Cameras
    public GameObject CustomerCamera;
    public GameObject PackingCamera;
    public GameObject CustomerOrder; 
    public bool CustomerView; 
    public bool PackingView; 

    public InMemoryVariableStorage variableStorage;

//fade in and out 
    public CanvasGroup canvasGroup; 
    public bool FadeIn;
    public bool FadeOut; 
   //[SerializeField] bool startFadedOut = false;
//Characters 
    public GameObject ReaVisual; 
    public GameObject ReaOrder; 
    public bool ReaEnabled; 
    public GameObject BusyVisual; 
    public GameObject BusyOrder; 
    public bool BusyEnabled; 
//Tipping
    public bool ReaTip; 
    public bool Tip; 
    public bool ReaBigTip; 
    public bool BigTip; 
//Puzzles
    public GameObject TutorialPuzzle; 
    public bool TutorialP;
    public GameObject Puzzle1; 
    public bool P1; 

    // Update is called once per frame
    void Update()
    {
        //Camera moving
        variableStorage.SetValue("$CustomerView", CustomerView);
        variableStorage.SetValue("$PackingView", PackingView);
       //Camera fading 
        variableStorage.SetValue("$FadeIn", FadeIn); 
        variableStorage.SetValue("$FadeOut", FadeOut); 
        //Characters 
        variableStorage.SetValue("$ReaEnabled", ReaEnabled); 
        variableStorage.SetValue("$ReaOrder", ReaOrder); 

        variableStorage.SetValue("$BusyEnabled", BusyEnabled); 
        variableStorage.SetValue("$BusyOrder", BusyOrder); 
        //tipping
        variableStorage.SetValue("$ReaTip", ReaTip);
        variableStorage.SetValue("$ReaBigTip", ReaBigTip);  

        //puzzles
        variableStorage.SetValue("$TutorialPuzzle", TutorialP);
        variableStorage.SetValue("$Puzzle1", P1);  
    }

//Camera Changing Commands 
    [YarnCommand("PackingView")]
    public void CamToPack()
    {
        PackingCamera.SetActive(true);
        CustomerCamera.SetActive(false);
    }
    
    [YarnCommand("CustomerView")]
    public void CamToCustomer()
    {
        CustomerCamera.SetActive(true);
        PackingCamera.SetActive(false);
        ReaOrder.SetActive(false);
        ReaVisual.SetActive(false);
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
    public void EnableRea()
    {
        ReaVisual.SetActive(true);
    }
    [YarnCommand("ReaOrder")]
    public void DisplayReaOrder()
    {
        ReaOrder.SetActive(true);
    }
    [YarnCommand("ReaTip")]
    public void ReaTipped()
    {
        Debug.Log("Rea tipped"); 
        Tip = true; 
    }
     [YarnCommand("ReaBigTip")]
    public void ReaTippedBig()
    {
        Debug.Log("Rea tipped BIG"); 
        BigTip = true; 
    }
//Business Character Commands 
    [YarnCommand("BusyEnabled")]
    public void EnableBusy()
    {
        BusyVisual.SetActive(true);
    }
    [YarnCommand("BusyOrder")]
    public void DisplayBusyOrder()
    {
        BusyOrder.SetActive(true);
    }
//Puzzle Commands 
     [YarnCommand("TutorialPuzzle")]
    public void DisablePuzzleT()
    {
        TutorialPuzzle.SetActive(false);
        Debug.Log("We should disable puzzle"); 
    }
     [YarnCommand("Puzzle1")]
    public void EnablePuzzle1()
    {
        Puzzle1.SetActive(true);
    }
}
