using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio; 

public class StopAudio : MonoBehaviour
{
    private EventInstance backgroundMusic; 
    private EventInstance ambientMusic; 
   
   private void Start()
   {
    backgroundMusic = AudioManager.instance.CreateInstance(FMODEvents.instance.BackgroundMusic); 
   }
   public void StopSound()
  {
    backgroundMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); 
    Debug.Log("We Tried"); 
  }
}
