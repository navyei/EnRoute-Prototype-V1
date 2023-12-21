using UnityEngine;

public class ButtonMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;

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

    public void MainMenu()
    {
        Time.timeScale = 1;
        GameManager.UpcomingScene = "MainMenu";
        GameManager.SceneChangeInput = true;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}

