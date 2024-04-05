using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 
using FMOD.Studio; 
// code from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class AudioManager : MonoBehaviour
{
  public static AudioManager instance {get; private set;}

  private EventInstance ambienceEventInstance; 
  //private EventInstance noiseEventInstance; 

//singleton. 
  private void Awake()
  {
    if (instance !=null)
    {
        Debug.LogError("Found more than one audio manager in the scene."); 
    }
    instance = this; 
  }

  private void Start()
  {
  //  InitializeAmbience(FMODEvents.instance.BackgroundMusic); 
    InitializeAmbience(FMODEvents.instance.BackgroundNoises); 
  }

  public void PlayOneShot(EventReference sound, Vector3 worldPos)
  {
    RuntimeManager.PlayOneShot(sound, worldPos); 

  }

  public EventInstance CreateInstance(EventReference eventReference)
  {
    EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
    return eventInstance; 
  }
  private void InitializeAmbience (EventReference ambienceEventReference)
  {
    ambienceEventInstance = CreateInstance(ambienceEventReference); 
    ambienceEventInstance.start(); 
  }
}
