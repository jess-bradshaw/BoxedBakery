using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity; 

public class Character : MonoBehaviour
{
   /* [System.Serializable] // texture Lookup for facial expressions 
    public class Expression {
        public string name; 
        public Texture2D texture; 
    }

    //objects needed to render new textures on character face 
    [SerializeField] List<Expression> expressions = new List<Expression>(); 
    [SerializeField] Renderer faceRenderer; 
    [SerializeField] int faceMaterialIndex; 

    // object needed to set Character pose 
    private Animator animator; 

    //when this character is first created 
    public void Awake()
    {
        //Set default expression 
        var defaultExpression = expressions[0].texture; 
        faceRender.materials[faceMaterialsIndex].mainTexture = defaultExpression; 
        animator = GetComponentInChildren<Animator>(); 
    }

    [YarnCommand("pose")]
    public void SetPose(string poseName)
    {
        string stateName = "Base Layer." + poseName; 
        Debug.Log($"{name} playing {stateName}");
        animator.Play(stateName, 0); 
    }

    [YarnCommand("expression")]
    public void SetExpression (string expressionName)
    {
        Expression expressionToUse = null; 
        foreach (var expression in expressions) 
        {
            if (expression.name.Equals(expressionName, System.StringComparison.InvariantCultureIgnoreCase))
            {
                expressionToUse = expression; 
                break;
            }
        }
    faceRender.materials[faceMaterialsIndex].mainTexture = expressionToUse.texture; 
    }
    */
}
