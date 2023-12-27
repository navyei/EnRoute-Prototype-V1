using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACController : InteractiveObject
{
    private bool isOn = false;

    public override void Interact()
    {
        // Implement AC-specific interaction logic here
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
        Debug.Log("AC is now on.");
        // Additional logic for turning on the AC

        // You can also call the base class Interact method if needed
        // base.Interact();
    }

    public void TurnOff()
    {
        isOn = false;
        Debug.Log("AC is now off.");
        // Additional logic for turning off the AC

        // You can also call the base class Interact method if needed
        // base.Interact();
    }
}
