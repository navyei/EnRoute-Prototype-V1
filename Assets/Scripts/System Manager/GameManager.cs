using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager :MonoBehaviour
{
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject managerObject = new GameObject("GameManager");
                instance = managerObject.AddComponent<GameManager>();
            }
            return instance;
        }
        
    }

    public int Score;
    public int RequiredScore;

    public int CO2_Count;

    public string UpcomingScene;
    public string[] InGameScenes;

    public bool SceneChangeInput = false;
    public bool LoadMultiple = false;
    public bool MinigameWin = false;

    private bool Loaded = false;
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void FixedUpdate()
    {
        if ( (Score == RequiredScore) || SceneChangeInput && !LoadMultiple) 
        {
            SceneManager.LoadScene(UpcomingScene);
        }
        else if ( (Score == RequiredScore) || SceneChangeInput && LoadMultiple && !Loaded)
        {
            LoadScenesOnce();
        }
        if (SceneChangeInput)
        {
            SceneChangeInput = false;
        }

        if (mini1Win = true)
        {
            Debug.Log("Minigame 1 win");
        }
    }

    public static bool mini1Win = false;
    public static bool mini2Win = false;
    public static bool mini3Win = false;
    void LoadScenesOnce()
    {
        foreach (string s in InGameScenes)
        {
            SceneManager.LoadScene(s, LoadSceneMode.Additive);
        }
        Loaded = true;
    }
}
