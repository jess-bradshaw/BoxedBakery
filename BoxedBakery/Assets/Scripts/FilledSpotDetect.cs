using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Code inspired by: https://www.youtube.com/watch?v=I17uqTxbWK0 & https://www.youtube.com/watch?v=FdxvTcHJiA8
public class FilledSpotDetect : MonoBehaviour
{
    public string item; 
    void OnTriggerStay2D(Collider2D other)
    {
       this.tag = "DropInvalid"; 
       item = other.name; 
    }
}
