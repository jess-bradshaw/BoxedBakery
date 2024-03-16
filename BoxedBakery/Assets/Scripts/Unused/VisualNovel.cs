using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 
// This scrip is from Mars Buttfileld-Addison and Jon Manning's GDC talk [https://www.youtube.com/watch?v=549J0eHE88k] 

public class VisualNovel : MonoBehaviour
{
   /* [SerializeField] CharacterList characterList; 
    private Dictionary<string, Character> characters = new Dictionary<string, Character>(); 
    private DialogueRunner dialogueRunner; // utility object that serves lines of dialogue 
   private FadeOverlay fadeOverlay; //black overlay used to fade in/out of scenes

   //when this visual novel object is created (when scene is loaded) needs to add commands so that they can be called in yarn spinner. 
   private void Awake()
   {
        //gets handles of utility objects in the scene that we need 
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
       // fadeOverlay = FindObjectOfType<FadeOverlay>(); 

        // <<camera NAME_OF_LOCATION>> 
        dialogueRunner.AddCommandHandler<Location>("camera", ChangeCameraLocation); 
        //<place NAME_OF_CHARACTER>> [First strong is character, and second is location you want to move it to]
        dialogueRunner.AddCommandHandler<string,string>("place", PlaceCharacter);

        //<<fadeIn DURATION>> 
        dialogueRunner.AddCommandHandler<float>("fadeIn", FadeIn); 
        //<<fadeOut DURATION>>
        dialogueRunner.AddCommandHandler<float>("fadeOut", FadeOut); 

   }
    //moves camera to camera location {location} in the scene 
    private void ChangeCameraLocation(Location location)
    {
        Camera.main.transform.position = location.cameraMarker.position; 
        Camera.main.transform.rotation = location.cameraMarker.rotation; 
    }
  
   private void PlaceCharacter(string characterName, string markerName) //GDC Yarn Spinner Talk 
    {
        Character character; 
        // if character isn't instantioned before, this does it for us.
        if (!characters.ContainsKey(characterName))
        {
        //    var characterPrefab = characterList.FindCharacterPrefab(characterName); 
        //    character = Instantiate(characterPrefab); 
            // and place it in the list of characters so we can find it next time. 
        //    characters[characterName] = character;
        }
        else 
        {
        //    character = characters[characterName]; 
        }
        //get the position/rotation of the destination marker in the scene 
        // and set the position/rotation of the character to there 
        //var marker = GameObject.Find(markerName); 
       // character.transform.position = marker.transform.position; 
       // character.transform.rotation = marker.transform.rotation; 
    }

    //fade in a black screen over {time} in seconds 
    private Coroutine FadeIn(float time =1f)
    {
        return StartCoroutine(fadeOverlay.FadeIn(time));
    }
      //fade out a black screen over {time} in seconds 
    private Coroutine FadeOut(float time =1f)
    {
        return StartCoroutine(fadeOverlay.FadeOut(time));
    }
    */
}
