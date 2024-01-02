using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject vehicleMenuPrefab; // Reference to the vehicle menu prefab
    private GameObject currentVehicleMenu; // Reference to the instantiated vehicle menu
    private Transform MainCamera;


    private void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void OnMouseDown()
    {
        // Check if the mouse click happened on the NPC
        if (Input.GetMouseButtonDown(0))
        {
            // Toggle the visibility of the vehicle menu
            ToggleVehicleMenu();
        }
    }

    void FixedUpdate()
    {
        transform.LookAt(MainCamera.transform.position);
    }

    void ToggleVehicleMenu()
    {
        // If the vehicle menu is already instantiated, destroy it
        if (currentVehicleMenu != null)
        {
            Destroy(currentVehicleMenu);
            currentVehicleMenu = null;
        }
        else
        {
            // Instantiate the vehicle menu prefab at the NPC's position
            currentVehicleMenu = Instantiate(vehicleMenuPrefab, transform.position, Quaternion.identity);

            // Attach a script to the instantiated menu to handle hiding it when a vehicle is chosen
            VehicleMenu vehicleMenuScript = currentVehicleMenu.GetComponent<VehicleMenu>();
            if (vehicleMenuScript != null)
            {
                vehicleMenuScript.SetNPCController(this);
            }
        }
    }

    public void HideVehicleMenu()
    {
        // Destroy the vehicle menu when a vehicle is chosen
        Destroy(currentVehicleMenu);
        currentVehicleMenu = null;
    }
}




