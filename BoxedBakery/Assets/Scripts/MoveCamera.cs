using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
 public GameObject CustomerCamera;
 public GameObject PackingCamera;


 void Awake()
 {
    
 }

    void customerAngle()
    {
        CustomerCamera.SetActive(true);
        PackingCamera.SetActive(false);
    }

    void packingAngle()
    {
        PackingCamera.SetActive(true);
        CustomerCamera.SetActive(false);
    }
}
