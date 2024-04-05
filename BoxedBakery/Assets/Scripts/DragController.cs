using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public Draggable LastDragged => _lastDragged;
    private bool _isDragActive = false; 
    private Vector2 _screenPosition; 
    private Vector3 _worldPosition;
    public float startPosX; //mouse position
    public float startPosY; //mouse position
    private Draggable _lastDragged; 

    //public Vector2 mousePos; 
    
    void Awake()
    {
        DragController [] controller = FindObjectsOfType<DragController>();  // checking to make sure there is only one drag controller in the scene 
        if (controller.Length >1)
        {
            Destroy(gameObject); //will delete extras 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if something is being dragged and the button is unpressed it will cause the object to be dropped. 
       if (_isDragActive && (Input.GetMouseButtonUp(0)))
       {
            Drop(); 
            return; 
       }
       
       //if the left mouse button is clicked. 
       if (Input.GetMouseButton(0)) 
        {
            Vector2 mousePos = Input.mousePosition; //get location of current mouse position
           // mousePos = Camera.main.ScreenToWorldPoint(mousePos); 
            _screenPosition = new Vector2(mousePos.x, mousePos.y); 
            //_worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition); 
           // startPosX = mousePos.x - this.transform.localPosition.x; //set to current mouse position [caculate different between center of item to where was clicked]
           // startPosY = mousePos.y - this.transform.localPosition.y; 
        }
        else 
        {
            return; 
        }
       _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition); 
         

        if (_isDragActive)
        {
            Drag(); 
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);  //draggable items need to have collider for this to work 
            if (hit.collider != null)
            {
                    Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                    if (draggable != null)
                    {
                        _lastDragged = draggable; 
                        InitDrag(); 
                    }
            }
        }
    }

    void InitDrag()
    {
        _lastDragged.LastPosition = _lastDragged.transform.position; 
        UpdateDragStatus(true);  
    }

    void Drag()
    {
        //Vector3 mousePos = Input.mousePosition;
        //mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        _lastDragged.transform.localPosition = new Vector3(_worldPosition.x - startPosX, _worldPosition.y - startPosY, -1);
       // _lastDragged.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY); 
    }

    void Drop()
    {
        UpdateDragStatus(false);  
        AudioManager.instance.PlayOneShot(FMODEvents.instance.ItemDropped, this.transform.position); 
    }

    void UpdateDragStatus (bool isDragging)
    {
        _isDragActive = _lastDragged.IsDragging = isDragging; 
        _lastDragged.gameObject.layer = isDragging ? Layer.Dragging : Layer.Default; 
    }
}
