using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectCounterAndSceneSwitcher : MonoBehaviour
{
    private int collidedObjectCount = 0;
    private float noCollisionTime = 0f;
    private bool countingStarted = false;

    // Adjust this value based on your requirements
    public float delayBeforeSceneChange = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            collidedObjectCount++;

            // If an 'obstacle' tagged object enters, stop the countdown
            countingStarted = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            collidedObjectCount--;

            // If no 'obstacle' tagged objects are colliding, start counting time
            if (collidedObjectCount == 0)
            {
                countingStarted = true;
            }
        }
    }

    void Update()
    {
        if (countingStarted)
        {
            noCollisionTime += Time.deltaTime;

            // If no 'obstacle' tagged objects are colliding for the specified delay, change the scene
            if (noCollisionTime >= delayBeforeSceneChange)
            {
                // Change the scene here
                SwitchScene();
            }
        }
        else
        {
            // If an 'obstacle' tagged object is present, reset the countdown
            noCollisionTime = 0f;
        }
    }

    void SwitchScene()
    {
        // Add logic here to switch to the desired scene
        SceneManager.LoadScene("Navigation");
    }
}



