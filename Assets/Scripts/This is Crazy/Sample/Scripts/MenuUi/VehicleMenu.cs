using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMenu : MonoBehaviour
{
    private NPCController npcController; // Reference to the NPCController

    public void SetNPCController(NPCController controller)
    {
        npcController = controller;
    }

    public void ChooseVehicle1()
    {
        Debug.Log("Vehicle 1 chosen!");
        // Add logic for handling Vehicle 1 selection here

        // Hide the vehicle menu
        if (npcController != null)
        {
            npcController.HideVehicleMenu();
        }

        // Turn off the canvas
        gameObject.SetActive(false);
    }

    public void ChooseVehicle2()
    {
        Debug.Log("Vehicle 2 chosen!");
        // Add logic for handling Vehicle 2 selection here

        // Hide the vehicle menu
        if (npcController != null)
        {
            npcController.HideVehicleMenu();
        }

        // Turn off the canvas
        gameObject.SetActive(false);
    }
}



