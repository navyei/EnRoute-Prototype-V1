using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameTrigger : MonoBehaviour
{
    public string collisionObjectName = "EventObject"; // Name of the object that triggers the event
    public string sceneToLoad = "YourSceneName"; // Specify the scene name to load

    private bool inMiniGame = false;

    void Update()
    {
        if (!inMiniGame)
        {
            CheckForEvents();
        }
    }

    void CheckForEvents()
    {
        // Check for collision with objects named "EventObject"
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f, transform.rotation, LayerMask.GetMask("Default"));

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(collisionObjectName))
            {
                // Collision with the event object detected
                // Optionally, you can perform additional actions here

                // Trigger the mini-game
                TriggerMiniGame();
            }
        }
    }

    void TriggerMiniGame()
    {
        if (!inMiniGame)
        {
            // Change the scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}