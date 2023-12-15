using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public float initialSpawnArea = 10.0f;
    public float spawnInterval = 2.0f;

    private float timer = 0.0f;

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if it's time to spawn a new object
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0.0f;

            // Increase spawn area by 2 units
            spawnInterval += 2.0f;
        }

        // Check for collision with "M1" during each update
        CheckForM1Collision();
    }

    private void SpawnObject()
    {
        // Generate a random position within the spawn area
        Vector3 spawnPosition = new Vector3(
            Random.Range(-initialSpawnArea, initialSpawnArea),
            10.0f, // Spawn at the top of the spawn area
            Random.Range(-initialSpawnArea, initialSpawnArea)
        );

        // Instantiate the object prefab at the random position
        GameObject newObj = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

        // Attach Rigidbody to the spawned object
        Rigidbody rb = newObj.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = newObj.AddComponent<Rigidbody>();
        }
        rb.useGravity = true; // Enable gravity for falling effect

        // Attach a script to handle collisions
        newObj.AddComponent<DestroyOnCollision>();
    }

    private void CheckForM1Collision()
    {
        // Check if the player collides with an object tagged as "M1"
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.0f); // You might need to adjust the radius
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("M1"))
            {
                // Player collided with "M1," handle loss condition and change scene
                HandleLoss();
            }
        }
    }

    private void HandleLoss()
    {
        // Add logic to handle loss (e.g., show game over screen, reset game, etc.)
        // For now, we'll just reload the navigation scene
        SceneManager.LoadScene("Navigation");
    }
}










