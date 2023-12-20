using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MultiPurposeInput :MonoBehaviour
{
    public string NextScene;
    public string[] TargetTag;
    
    //Input with Buttons
    public void SceneChangeInput()
    {
        GameManager.UpcomingScene = NextScene;
        GameManager.SceneChangeInput = true;
    }

    //Detect Input with Trigger
    private void OnTriggerEnter(Collider other)
    {
        foreach (string Tag in TargetTag)
        {
            if (other.CompareTag(Tag))
            {
                SceneChangeInput();
            }
        }
        
    }

}