using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        // If we're running in the Unity editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // If we're running in a build version
            Application.Quit();
#endif
    }
}
