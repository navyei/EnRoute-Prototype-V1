using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedalsController : InteractiveObject
{
    private bool isPressed = false;

    public bool IsPressed()
    {
        return isPressed;
    }

    public override void Interact()
    {
        // Implement pedals-specific interaction logic here
        if (isPressed)
        {
            ReleasePedals();
        }
        else
        {
            PressPedals();
        }
    }

    public void PressPedals()
    {
        isPressed = true;
        Debug.Log("Pedals are pressed.");
        // Additional logic for pressing the pedals
    }

    public void ReleasePedals()
    {
        isPressed = false;
        Debug.Log("Pedals are released.");
        // Additional logic for releasing the pedals
    }
}

