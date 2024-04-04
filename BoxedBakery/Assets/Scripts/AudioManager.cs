using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 
// code from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class AudioManager : MonoBehaviour
{
  public static AudioManager instance {get; private set;}


//singleton. 
  private void Awake()
  {
    if (instance !=null)
    {
        Debug.LogError("Found more than one audio manager in the scene."); 
    }
    instance = this; 
  }

  public void PlayOneShot(EventReference sound, Vector3 worldPos)
  {
    RuntimeManager.PlayOneShot(sound, worldPos); 
  }
}
