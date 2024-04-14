using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity; 
// code from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class FMODEvents : MonoBehaviour
{
   //SFX
   [field: Header("Item Dropped SFX")]
   [field: SerializeField] public EventReference ItemDropped {get; private set;} 
   [field: Header("Item PickedUp SFX")]
   [field: SerializeField] public EventReference ItemPickedUp {get; private set;} 
   [field: Header("Tip SFX")]
   [field: SerializeField] public EventReference CoinTipped {get; private set;} 
   [field: Header("Payment SFX")]
   [field: SerializeField] public EventReference CoinPaid {get; private set;} 
    [field: Header("Continue SFX")]
   [field: SerializeField] public EventReference ContinueButton {get; private set;} 
   [field: Header("Door Sound")]
   [field: SerializeField] public EventReference DoorSound {get; private set;} 

//Music 
   [field: Header("Background Music")]
   [field: SerializeField] public EventReference BackgroundMusic {get; private set;} 
   [field: Header("Background Noises")]
   [field: SerializeField] public EventReference BackgroundNoises {get; private set;} 
   

    public static FMODEvents instance {get; private set;}
   private void Awake()
   {
    if (instance != null)
    {
        Debug.LogError("Found more than one FMOD Events instance in the scene.");
    }
    instance = this; 
   }
}
