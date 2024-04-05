using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayAudioSound(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.ContinueButton, this.transform.position); 
    }
}
