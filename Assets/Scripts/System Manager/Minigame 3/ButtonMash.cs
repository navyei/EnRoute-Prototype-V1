using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMasher : MonoBehaviour
{
    public Slider progressBar;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI gameWinText;
    public float decreaseRate = 1f;
    public float increaseAmount = 0.1f;
    public float winThreshold = 0.75f;
    private float timeRemain = 10f;
    private float startDelay = 1f;
    private bool _gameEnded = false;
    private bool _gameStarted = false; // Added variable to track game start
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        gameOverText.enabled = false;
        gameWinText.enabled = false;
        progressBar.value = 0.1f; // Ensure game over text is hidden initially

    }

    void Update()
    {
        if (_gameEnded)
        {
            return; // Stop updating the game if it's over
        }

        if (!_gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            _gameStarted = true;
        }

        if (_gameStarted)
        {
            // Existing logic remains the same

            if (Input.GetKeyDown(KeyCode.Space))
            {
                float increaseFactor = Mathf.Exp(-progressBar.value * 2f);
                progressBar.value += increaseAmount * increaseFactor;
            }

            progressBar.value -= decreaseRate * Time.deltaTime;
            timeRemain -= Time.deltaTime;
            startDelay -= Time.deltaTime;

            if (progressBar.value <= 0)
            {
                EndGame();
            }

            if (timeRemain <= 0f)
            {
                if (progressBar.value >= winThreshold)
                {
                    GameWin();
                }
                else
                {
                    EndGame();
                }
            }
        }
    }

    void EndGame()
    {
        GameManager.mini3Win = false;
        _gameEnded = true;
        gameOverText.enabled = true;
    }

    void GameWin()
    {
        GameManager.mini3Win = true;
        _gameEnded = true;
        gameWinText.enabled = true;
    }
}
