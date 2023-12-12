using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Minigame : MonoBehaviour
{
    public float timeLimit = 20f;
    private float timer;
    public TextMeshProUGUI gameWinText;
    public TextMeshProUGUI gameLoseText;
    public List<DraggableCar> cars;

    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        foreach (var car in cars)
        {
            if (car.gameObject.activeInHierarchy)
            {
                // Lose condition
                Debug.Log("You lose!");
                gameLoseText.enabled = true;
                return;
            }
        }
        // Win condition
        Debug.Log("You win!");
        gameWinText.enabled = true;
    }
}
