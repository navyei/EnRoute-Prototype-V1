using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public GameObject[] miniGames;

    void Start()
    {
        // Deactivate all mini-games initially
        foreach (GameObject miniGame in miniGames)
        {
            miniGame.SetActive(false);
        }

        // Activate a random mini-game
        int randomIndex = Random.Range(0, miniGames.Length);
        miniGames[randomIndex].SetActive(true);
    }
}
