using System.Collections;
using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public static VehicleSpawner Instance;

    public GameObject taxiPrefab; // Reference to the Taxi prefab
    public GameObject carPrefab;  // Reference to the Car prefab

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to spawn a vehicle based on the player's selection
    public void SpawnVehicle(string vehicleType, Vector3 spawnPosition)
    {
        GameObject vehiclePrefab = GetVehiclePrefab(vehicleType);

        // Spawn the selected vehicle
        if (vehiclePrefab != null)
        {
            Instantiate(vehiclePrefab, spawnPosition, Quaternion.identity);
        }
    }

    private GameObject GetVehiclePrefab(string vehicleType)
    {
        switch (vehicleType)
        {
            case "Taxi":
                return taxiPrefab;
            case "Car":
                return carPrefab;
            // Add more cases for other vehicle types if needed

            default:
                Debug.LogWarning("Unknown vehicle type: " + vehicleType);
                return null;
        }
    }
}


