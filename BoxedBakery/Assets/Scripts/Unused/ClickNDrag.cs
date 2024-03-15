using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickNDrag : MonoBehaviour
{

    private float startPosX; //mouse position
    private float startPosY; //mouse position
    private bool isBeingHeld = false; 
  
   // Update is called once per frame
    void Update()
    {
       if(isBeingHeld == true)
       {
            Vector3 mousePos; 
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0); 
       } 
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos; 
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x; //set to current mouse position [caculate different between center of item to where was clicked]
            startPosY = mousePos.y - this.transform.localPosition.y;
            isBeingHeld = true; 
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false; 
    }
   

}
