using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiPurposeInput :MonoBehaviour
{
    public string NextScene;
    public string[] TargetTag;
    public GameObject pauseMenu;

    private bool TargetInput;

    private void Start()
    {
        GameManager.UpcomingScene = "";
        GameManager.SceneChangeInput = false;
    }
    private void Update()
    {
        if (TargetInput)
        {
            GameManager.UpcomingScene = NextScene;
            GameManager.SceneChangeInput = true;
        }
    }

    //Input for Buttons
    public void SceneChangeInput()
    {
        TargetInput = true;
    }

    //Pause Menu Utilities
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1;
        TargetInput = true;
    }

    //Detect Input with Trigger
    private void OnTriggerEnter(Collider other)
    {
        foreach (string Tag in TargetTag)
        {
            if (other.CompareTag(Tag))
            {
                TargetInput = true;
            }
        }
        
    }

}