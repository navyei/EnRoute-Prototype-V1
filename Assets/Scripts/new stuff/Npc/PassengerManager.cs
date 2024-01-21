using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    public GameObject passengerPrefab;
    public GameObject destinationPrefab;

    // Specify spawn and destination positions in the Unity Editor
    public Vector3 spawnPosition;
    public Vector3 destinationPosition;

    private void Start()
    {
        // Spawn the initial passenger
        SpawnPassenger();
    }

    private void SpawnPassenger()
    {
        // Instantiate a new passenger prefab at the specified spawn position
        Instantiate(passengerPrefab, spawnPosition, Quaternion.identity);
    }

    public void PassengerPickedUp()
    {
        // This method is called when the taxi picks up the passenger
        // Now, spawn the destination
        DestroyPassengerAndPickupZone();
        SpawnDestination();
    }

    private void DestroyPassengerAndPickupZone()
    {
        // Find the passenger and its associated pick-up zone
        GameObject passenger = GameObject.FindGameObjectWithTag("Passenger");
        if (passenger != null)
        {
            // Call the OnPickedUp method of the Passenger script
            passenger.GetComponent<Passenger>().OnPickedUp();
        }

        GameObject pickUpZone = GameObject.FindGameObjectWithTag("PickUpZone");
        if (pickUpZone != null)
        {
            Destroy(pickUpZone);
        }
    }

    private void SpawnDestination()
    {
        // Instantiate a new destination prefab at the specified destination position
        Instantiate(destinationPrefab, destinationPosition, Quaternion.identity);
    }
}


