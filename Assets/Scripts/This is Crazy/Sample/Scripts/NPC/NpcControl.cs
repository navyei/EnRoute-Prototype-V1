using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject vehicleMenuPrefab;
    private GameObject currentVehicleMenu;

    private Transform MainCamera;

    private void OnMouseDown()
    {
        if (currentVehicleMenu == null)
        {
            currentVehicleMenu = Instantiate(vehicleMenuPrefab, transform.position, Quaternion.identity);
            VehicleMenu vehicleMenuScript = currentVehicleMenu.GetComponent<VehicleMenu>();

            if (vehicleMenuScript != null)
            {
                vehicleMenuScript.SetNPCController(this);
            }
        }
    }

    public void RequestVehicleSpawn(string vehicleType)
    {
        VehicleSpawner.Instance.SpawnVehicle(vehicleType, transform.position + Vector3.up);
        HideVehicleMenu();
    }

    public void HideVehicleMenu()
    {
        Destroy(currentVehicleMenu);
        currentVehicleMenu = null;
    }
    
    
    // Method to make the NPC face the camera (3D setup)
    private void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(MainCamera.transform.position);
    }

}





