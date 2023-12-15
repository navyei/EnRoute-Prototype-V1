using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputToChangeScene :MonoBehaviour
{
    public string SceneName;

    private bool TargetInput;

    private void Awake()
    {
        GameManager GM = FindObjectOfType<GameManager>();
        TargetInput = false;
        GM.UpcomingScene = "";
    }
    public void Input()
    {
        TargetInput = true;
    }
    private void Update()
    {
        GameManager GM = FindObjectOfType<GameManager>();
        if (TargetInput && GM != null)
        {
            GM.UpcomingScene = SceneName;
            GM.SceneChangeInput = true;
        }
    }
}
