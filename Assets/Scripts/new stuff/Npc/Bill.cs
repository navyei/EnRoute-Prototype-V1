using UnityEngine;

public class Bill : MonoBehaviour
{
    // Assigned objects to be destroyed by the car
    public GameObject objectToDestroyA;
    public GameObject objectToDestroyB;

    // Flag to track if the car is inside the trigger collider
    private bool isCarInsideColliderB = false;

    // Timer to count the waiting time
    private float timer = 0f;

    // The time the car should wait inside the trigger before destroying objects
    public float waitingTime = 5f;

    // Called when the car enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the tag 'npc'
        if (other.CompareTag("Player"))
        {
            // Set the flag to true
            isCarInsideColliderB = true;
        }
    }

    // Called when the car exits the trigger collider
    void OnTriggerExit(Collider other)
    {
        // Check if the exiting object has the tag 'npc'
        if (other.CompareTag("Player"))
        {
            // Reset the flag and timer
            isCarInsideColliderB = false;
            timer = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the car is inside the trigger collider
        if (isCarInsideColliderB)
        {
            // Increment the timer
            timer += Time.deltaTime;

            // Check if the waiting time has elapsed
            if (timer >= waitingTime)
            {
                // Destroy the assigned objects
                Destroy(objectToDestroyA);
                Destroy(objectToDestroyB);

                // Reset the flag and timer
                isCarInsideColliderB = false;
                timer = 0f;
            }
        }
    }
}










