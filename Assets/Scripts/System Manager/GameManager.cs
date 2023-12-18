using System.Collections;
using System.Collections.Generic;
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
                DontDestroyOnLoad(managerObject);
            }
            return instance;
        }
        
    }

    public int Score;
    public int RequiredScore;

    public int CO2_Count;
    public string UpcomingScene;
    public bool SceneChangeInput = false;
    public bool InGame = false;
    public bool MinigameWin = false;

    private void FixedUpdate()
    {
        if ( (Score == RequiredScore) || SceneChangeInput && !InGame) 
        {
            SceneManager.LoadScene(UpcomingScene);
        }
        else if ((Score == RequiredScore) || SceneChangeInput && InGame)
        {
            SceneManager.LoadScene(UpcomingScene, LoadSceneMode.Additive);
        }
    }

    public bool mini1Win = false;
    public bool mini2Win = false;
    public bool mini3Win= false;
}
