using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneTrigger : MonoBehaviour
{
    public string sceneToLoad = "Minigame 1"; // Replace with the name of the scene you want to load

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has a specific tag (e.g., "Start")
        if (other.CompareTag("Start"))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

