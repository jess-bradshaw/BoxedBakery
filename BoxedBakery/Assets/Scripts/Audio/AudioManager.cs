using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 
using FMOD.Studio; 
// code from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class AudioManager : MonoBehaviour
{
  public static AudioManager instance {get; private set;}

  public EventInstance ambienceEventInstance; 
   public EventInstance BackgroundMusic; 
  //public bool PlayMusic; 
  public bool MusicOn; 
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
    
       // PLAYBACK_STATE playbackState; 
      //  BackgroundMusic.getPlaybackState(out playbackState);  
    //if (playbackState.Equals(PLAYBACK_STATE.STOPPED)) {
      if(MusicOn == false){
      InitializeAmbience(FMODEvents.instance.BackgroundMusic); 
      InitializeAmbience(FMODEvents.instance.BackgroundNoises); 
      MusicOn = true; 
    }

  }

  public void PlayOneShot(EventReference sound, Vector3 worldPos) //This is used to play one off music clips
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
  public void SetAmbienceParameter (string parameterName, float parameterValue)
  {
    ambienceEventInstance.setParameterByName(parameterName, parameterValue); 
    Debug.Log("We quiet"); 

  }
}
