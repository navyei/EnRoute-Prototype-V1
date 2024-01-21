using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisibility : MonoBehaviour
{
    void Update()
    {
        // Check if Shift key is being held down
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            ShowCursor();
        }
        else
        {
            HideCursor();
        }
    }

    void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void HideCursor()
    {
        // Hide and lock the cursor as per your game's requirement
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

