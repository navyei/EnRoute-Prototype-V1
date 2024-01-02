
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject[] npcPrefabs; // Array of NPC prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public int numberOfNPCs = 5; // Number of NPCs to spawn
    public float spawnInterval = 2f; // Time between spawns

    private List<Transform> availableSpawnPoints; // List to track available spawn points

    void Start()
    {
        if (numberOfNPCs > spawnPoints.Length)
        {
            Debug.LogWarning("Not enough spawn points for the specified number of NPCs!");
            numberOfNPCs = spawnPoints.Length;
        }

        availableSpawnPoints = new List<Transform>(spawnPoints); // Initialize availableSpawnPoints with all spawn points

        // InvokeRepeating allows you to call a method repeatedly with a specified delay and interval
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if (numberOfNPCs <= 0 || availableSpawnPoints.Count == 0)
        {
            Debug.Log("All NPCs have been spawned or all spawn points are occupied!");
            CancelInvoke("SpawnObject"); // Stop spawning when all NPCs are spawned or all spawn points are occupied
            return;
        }

        // Randomly choose an NPC prefab from the array
        GameObject chosenNPCPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];

        // Randomly choose an index from the available spawn points list
        int randomIndex = Random.Range(0, availableSpawnPoints.Count);

        // Get the chosen spawn point from the list
        Transform chosenSpawnPoint = availableSpawnPoints[randomIndex];

        // Instantiate the chosen NPC prefab at the chosen spawn point
        Instantiate(chosenNPCPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);

        // Remove the chosen spawn point from the available list
        availableSpawnPoints.RemoveAt(randomIndex);

        numberOfNPCs--;
    }
}


