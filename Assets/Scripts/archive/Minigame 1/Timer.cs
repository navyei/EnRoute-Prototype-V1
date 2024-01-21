using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30f;

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            GameManager.Instance.UpcomingScene = "Gameplay";
            GameManager.Instance.SceneChangeInput = true;
        }
    }
}