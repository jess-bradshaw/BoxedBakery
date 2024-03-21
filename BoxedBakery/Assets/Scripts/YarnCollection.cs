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
   [SerializeField] bool startFadedOut = false;
//Characters 
    public GameObject ReaVisual; 
    public bool ReaEnabled; 

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
    }

//Camera Changing Commands 
    [YarnCommand("PackingView")]
    public void CamToPack()
    {
        PackingCamera.SetActive(true);
        CustomerCamera.SetActive(false);
        CustomerOrder.SetActive(true);
    }
    
    [YarnCommand("CustomerView")]
    public void CamToCustomer()
    {
        CustomerCamera.SetActive(true);
        PackingCamera.SetActive(false);
        CustomerOrder.SetActive(false);
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
           // Debug.Log(canvasGroup.alpha); 
            //Debug.Log(to+ "To value"); 

            yield return null;
            elapsed += Time.deltaTime;
        }
        canvasGroup.alpha = to;
        Debug.Log("We faded?"); 
    }

    //Character Enabling 
    [YarnCommand("ReaEnabled")]
    public void EnableRea()
    {
        ReaVisual.SetActive(true);
        Debug.Log("We called it to enable"); 
    }
    
}
