using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))] 
public class FadeOverlay : MonoBehaviour
{
    [SerializeField] bool starFadeOut = false; 
    private CanvasGroup canvasGroup; 
    
    
    private void Awake()
    {
    canvasGroup = GetComponent<CanvasGroup>(); 

    canvasGroup.alpha = starFadeOut ? 1 : 0; 

    }

    //A coroutine that fades in from black to transparent over time in seconds 
    public IEnumerator FadeIn(float time)
    {
        yield return StartCoroutine(Fade(1, 0, time));
    }

    // A coroutine that fades out from transparet to black over time in seconds 
    public IEnumerator FadeOut(float time)
    {
        yield return StartCoroutine(Fade(0, 1, time)); 
    }

    // a coroutine that fades from transparecy level to another over time in seconds 
    public IEnumerator Fade(float from, float to, float time)
    {
        canvasGroup.alpha = from; 

        float elapsed = 0f; 

        while (elapsed < time) {
            var factor = elapsed /time; 

            canvasGroup.alpha = Mathf.Lerp(from, to, factor); 

            yield return null; 
            elapsed += Time.deltaTime; 
        }
        canvasGroup.alpha = to; 
    }
}
