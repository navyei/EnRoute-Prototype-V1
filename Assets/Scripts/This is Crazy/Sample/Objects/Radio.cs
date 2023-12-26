using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : InteractiveObject
{
    private bool isOn = false;

    public bool IsOn()
    {
        return isOn;
    }

    public override void Interact()
    {
        // Implement Radio-specific interaction logic here
        if (isOn)
        {
            TurnOff();
        }
        else
        {
            TurnOn();
        }
    }

    public void TurnOn()
    {
        isOn = true;
        Debug.Log("Radio is now on.");
        // Additional logic for turning on the radio
    }

    public void TurnOff()
    {
        isOn = false;
        Debug.Log("Radio is now off.");
        // Additional logic for turning off the radio
    }
}
