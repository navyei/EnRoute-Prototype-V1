using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Mini2:MonoBehaviour
{
    public float timeLimit = 20f;
    private float timer;
    public TextMeshProUGUI gameWinText;
    public TextMeshProUGUI gameLoseText;
    public List<DraggableCar> cars;
    private GameManager gameManager;
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
                gameManager.mini2Win = false;
                return;
            }
        }
        // Win condition
        Debug.Log("You win!");
        gameWinText.enabled = true;
        gameManager.mini2Win = true;
    }
}
