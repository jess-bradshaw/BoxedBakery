using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D cursorArrow; 
    public Texture2D cursorArrowClicked; 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor (cursorArrow, Vector2.zero, CursorMode.ForceSoftware); 
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetMouseButton(0)) 
        {
            Cursor.SetCursor (cursorArrowClicked, Vector2.zero, CursorMode.ForceSoftware); 
        }
        else 
        {
            Cursor.SetCursor (cursorArrow, Vector2.zero, CursorMode.ForceSoftware); 
        }

    }
}
