using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputToChangeScene :MonoBehaviour
{
    public string NextScene;
    public GameObject ObjectTrigger;
    public bool LoadMultiple;

    private bool TargetInput;

    private void Awake()
    {
        GameManager GM = FindObjectOfType<GameManager>();
        TargetInput = false;
        if ( GM != null)
        {
            GM.UpcomingScene = "";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Start"))
        {
            TargetInput = true;
        }
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
            if (LoadMultiple)
            {
                GM.LoadMultiple = true;
                GM.UpcomingScene = NextScene;
            }
            else
            {
                GM.UpcomingScene = NextScene;
            }
            GM.SceneChangeInput = true;
        }
    }
}