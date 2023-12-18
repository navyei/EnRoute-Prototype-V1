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

    private void FixedUpdate()
    {
        if ( (Score == RequiredScore)||(SceneChangeInput == true) ) 
        {
            SceneManager.LoadScene(UpcomingScene);
        }
    }

    public bool mini1Win = false;
    public bool mini2Win = false;
    public bool mini3Win= false;
}
