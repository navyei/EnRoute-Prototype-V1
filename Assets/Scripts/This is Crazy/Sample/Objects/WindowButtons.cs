using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowButtonController : InteractiveObject
{
    private bool isOpen = false;

    public bool IsOpen()
    {
        return isOpen;
    }

    public override void Interact()
    {
        // Implement window button-specific interaction logic here
        if (isOpen)
        {
            CloseWindow();
        }
        else
        {
            OpenWindow();
        }
    }

    public void OpenWindow()
    {
        isOpen = true;
        Debug.Log("Window is now open.");
        // Additional logic for opening the window
    }

    public void CloseWindow()
    {
        isOpen = false;
        Debug.Log("Window is now closed.");
        // Additional logic for closing the window
    }
}


