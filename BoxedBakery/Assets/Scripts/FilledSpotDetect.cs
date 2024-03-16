using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilledSpotDetect : MonoBehaviour
{
    public string item; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
       this.tag = "DropInvalid"; 
       item = other.name; 
}
}
