using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                isPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                isPaused = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

    }
}
