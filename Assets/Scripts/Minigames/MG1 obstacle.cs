
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1obstacle : MonoBehaviour
{
    public GameObject objectPrefab;
    public float spawnInterval = 1f;
    private float timer = 0;

    void Start()
    {
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            SpawnObject();
            timer = 0;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 10f, Random.Range(-10f, 10f));
        Instantiate(objectPrefab, spawnPosition, Quaternion.identity);

    }
}
