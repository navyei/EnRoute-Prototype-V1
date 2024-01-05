using UnityEngine;

public class MultiPurposeInput : MonoBehaviour
{
    public bool UsedForScenes;
    public bool UsedForScore;
    public int RequiredScore;
    public string[] TargetTag;
    public string NextScene;

    public int Score;
    //Input with Buttons
    public void SceneChangeInput()
    {
        GameManager.Instance.UpcomingScene = NextScene;
        GameManager.Instance.SceneChangeInput = true;
    }
    public void ScoreCounter()
    {
        GameManager.Score++;
    }

    //Detect Input with Trigger
    private void OnTriggerEnter(Collider other)
    {
        foreach (string Tag in TargetTag)
        {
            if (other.CompareTag(Tag))
            {
                if (UsedForScenes)
                {
                    SceneChangeInput();
                }
                if (UsedForScore)
                {
                    ScoreCounter();
                    other.gameObject.SetActive(false);
                }
            }
        }
    }

}