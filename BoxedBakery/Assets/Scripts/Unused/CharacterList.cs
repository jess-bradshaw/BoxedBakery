using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A scriptable object that stores a list of references to character objects 
// [CreateAssetMenu(fileName = "CharacterList", menuName = "Visual Novel/Character List", order = 0)]
public class CharacterList : ScriptableObject 
{
    //give a character name, return the prefab for the characther that has that name 
/* 
    public Character FindCharacterPrefab(string name)
    {
       foreach (var character in characters)
        {
            if (character.name.Equals(name, System.StringComparison.InvariantCultureIgnoreCase))
            {
                return character; 
            }
        }
        return null; 
    }*/
}
