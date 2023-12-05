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
    private float timeLeft = 10f;
    private float startdelay = 1f;
    private bool gameEnded = false;
    private bool gameWin = false;

    void Start()
    {
        gameOverText.enabled = false;
        gameWinText.enabled = false;
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
        timeLeft -= Time.deltaTime;
        startdelay -= Time.deltaTime;
        if (timeLeft <= 0f && progressBar.value > 5)
        {
            GameWin();
        }
        if (timeLeft <= 0f && progressBar.value < 5|| progressBar.value <= 0 && startdelay <=0f)
        {
            EndGame();
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
        gameWin = true;
        gameEnded = true;
        gameWinText.enabled = true;
    }
}