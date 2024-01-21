using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    // You can add any passenger-specific behavior or properties here

    private void Start()
    {
        // Make the passenger face the negative x-axis
        transform.forward = -Vector3.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // This is called when the passenger collides with the taxi
            OnPickedUp();
        }
    }

    public void OnPickedUp()
    {
        // This method is called when the passenger is picked up
        // You can add any specific behavior you want here

        // For now, we'll disable the passenger GameObject
        gameObject.SetActive(false);

        // Notify the manager that the passenger is picked up
        FindObjectOfType<PassengerManager>().PassengerPickedUp();
    }
}

