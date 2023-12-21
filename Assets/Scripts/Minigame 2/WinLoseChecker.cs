using UnityEngine;

public class WinLoseChecker : MonoBehaviour
{
    public float timeLimit = 20f; // Time limit in seconds
    private bool gameWon = false;
    private float timer;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && !gameWon)
        {
            CheckGameOutcome();
        }
    }

    void CheckGameOutcome()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, GetComponent<BoxCollider>().size / 2);
        bool obstacleInside = false;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Obstacle"))
            {
                obstacleInside = true;
                break;
            }
        }

        if (obstacleInside)
        {
            Debug.Log("Game Lost: Obstacle(s) still inside.");
            // Implement game lost logic here
            GameManager.mini2Win = false;
        }
        else
        {
            Debug.Log("Game Won: No obstacles inside.");
            gameWon = true;
            // Implement game won logic here
            GameManager.mini2Win = true;
        }
    }
}