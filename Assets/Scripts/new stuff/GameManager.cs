using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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

    public string UpcomingScene;
    public bool SceneChangeInput;
    public bool InGame;

    public static int Score;
    public int RequiredScore;
    public int CO2_Count;
    public bool MinigameWin;

    public Camera Camera;
    public TMPro.TMP_Text ScoreCounter;
    public CinemachineVirtualCameraBase[] CameraDollies;
    private void Start()
    {
        //In-Game Camera Switching Pt.1 (Do not change)
        if (InGame)
        {
            for (int i = 1; i < CameraDollies.Length; i++)
            {
                CameraDollies[i].Priority = i;
            }
        }
        //End of In-Game Camera Switching Pt.1
    }
    private void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (SceneChangeInput)
        {
            SceneManager.LoadScene(UpcomingScene);
        }
        if (ScoreCounter != null)
        {
            ScoreCounter.text = "Score: " + Score.ToString();
        }

        if (mini1Win == true)
        {
            Debug.Log("Minigame 1 win");
        }
    }

    public static bool mini1Win = false;
    public static bool mini2Win = false;
    public static bool mini3Win = false;

    //In-Game Camera Switching Pt.2 (Do not change)
    public void PrevCamera()
    {
        SwitchCam(0);
    }
    public void NextCamera()
    {
        SwitchCam(1);

    }

    void SwitchCam(int IndexNumber)
    {
        if (IndexNumber >= 0 && IndexNumber < CameraDollies.Length)
        {
            foreach (var Cam in CameraDollies)
            {
                Cam.gameObject.SetActive(false);
            }
            CameraDollies[IndexNumber].gameObject.SetActive(true);
        }
    }
    //End of In-Game Camera Switching Pt.2
}