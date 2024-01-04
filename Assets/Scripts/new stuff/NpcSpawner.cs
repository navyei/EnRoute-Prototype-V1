using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcSpawner : MonoBehaviour
{
    public GameObject[] npcPrefabs;
    public Transform[] spawnPoints;
    public int numberOfNPCs = 5;
    public float spawnInterval = 2f;

    private List<Transform> availableSpawnPoints;

    void Start()
    {
        if (numberOfNPCs > spawnPoints.Length)
        {
            Debug.LogWarning("Not enough spawn points for the specified number of NPCs!");
            numberOfNPCs = spawnPoints.Length;
        }
        availableSpawnPoints = new List<Transform>(spawnPoints);
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if (numberOfNPCs <= 0 || availableSpawnPoints.Count == 0)
        {
            Debug.Log("All NPCs have been spawned or all spawn points are occupied!");
            CancelInvoke("SpawnObject");
            return;
        }
        GameObject chosenNPCPrefab = npcPrefabs[Random.Range(0, npcPrefabs.Length)];
        int randomIndex = Random.Range(0, availableSpawnPoints.Count);
        Transform chosenSpawnPoint = availableSpawnPoints[randomIndex];
        Instantiate(chosenNPCPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
        availableSpawnPoints.RemoveAt(randomIndex);
        numberOfNPCs--;
    }
}


