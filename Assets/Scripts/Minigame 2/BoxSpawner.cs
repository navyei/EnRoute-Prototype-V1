using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs
    public Vector3 spawnAreaMin; // Minimum coordinates of the spawn area
    public Vector3 spawnAreaMax; // Maximum coordinates of the spawn area
    public float initialSpawnInterval = 0.3f; // Initial time between spawns
    public float decreaseRate = 0.5f; // Rate at which the spawn interval decreases
    public float minimumInterval = 0.15f; // Minimum spawn interval
    public float difficultyIncreaseInterval = 10f; // Interval for difficulty increase

    private float spawnInterval;
    private float spawnTimer;
    private float difficultyTimer;

    void Start()
    {
        spawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        difficultyTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnObstacle();
            spawnTimer = 0;
        }

        if (difficultyTimer >= difficultyIncreaseInterval)
        {
            IncreaseDifficulty();
            difficultyTimer = 0;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogError("No obstacle prefabs assigned!");
            return;
        }

        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            Random.Range(spawnAreaMin.y, spawnAreaMax.y),
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)
        );

        GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);
    }

    void IncreaseDifficulty()
    {
        spawnInterval = Mathf.Max(minimumInterval, spawnInterval * decreaseRate);
    }
}