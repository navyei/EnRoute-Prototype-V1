using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tSpawner : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform[] spawnPoints;
    public float initialDelay = 2.0f; // Adjust the initial delay before the first spawn
    public float spawnInterval = 2.0f; // Adjust the interval between spawns
    public int minObjectsToSpawn = 1; // Minimum number of objects to spawn
    public int maxObjectsToSpawn = 5; // Maximum number of objects to spawn

    void Start()
    {
        // Call the SpawnObjects method after the initial delay and then repeatedly after the specified interval
        InvokeRepeating("SpawnObjects", initialDelay, spawnInterval);
    }

    void SpawnObjects()
    {
        int numObjectsToSpawn = Random.Range(minObjectsToSpawn, maxObjectsToSpawn + 1);

        for (int i = 0; i < numObjectsToSpawn; i++)
        {
            // Randomly select a spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Spawn the object
            Instantiate(objectPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}


