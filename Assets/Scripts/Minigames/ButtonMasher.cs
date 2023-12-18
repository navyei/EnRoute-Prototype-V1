using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private bool gameEnded ;
    private GameManager gameManager;


    void Start()
    {
        gameOverText.enabled = false;
        gameWinText.enabled = false;
        gameManager = GameObject.FindObjectOfType<GameManager>();
        progressBar.value = 0.1f; // Ensure game over text is hidden initially
    }

    void Update()
    {
        if (gameEnded)
        {
            return; // Stop updating the game if it's over
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Exponential decrease in increase amount as the progress bar approaches 1
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
        if (timeRemain <= 0f )
        {
            if (progressBar.value >= winThreshold)
            {
                GameWin();
                gameManager.mini3Win = true;
            }
            else
            {
                EndGame();
                gameManager.mini3Win = false;
            }
            
        }
        
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverText.enabled = true; // Show the game over text
        // Optionally, you can also disable the spacebar input here
    }

    void GameWin()
    {
        gameEnded = true;
        gameWinText.enabled = true;
    }
}