using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public Text uiText;
    public RadioController radioController;
    public ACController acController;
    public PedalsController pedalsController;
    public WindowButtonController windowButtonsController;

    // Blinking effect
    public Color StartColor = Color.green;
    public Color EndColor = Color.red;
    [Range(0, 5)]
    public float speed = 1.0f;
    Renderer ren;

    // Time the NPC is spawned
    private float spawnTime = 15f;

    // Flag to control blinking
    private bool isBlinking = false;

    private void Start()
    {
        ren = GetComponent<Renderer>();

        // Initialization code
        if (uiText == null)
        {
            uiText = GetComponentInChildren<Text>();
            if (uiText == null)
            {
                Debug.LogError("UI Text not found in NPC GameObject hierarchy!");
            }
        }

        // Start asking for needs when the game begins
        StartCoroutine(SpawnAndAskForNeeds());
    }

    void Update()
    {
        // Check if blinking is enabled
        if (isBlinking)
        {
            ren.material.color = Color.Lerp(StartColor, EndColor, Mathf.PingPong(Time.time * speed, 1));
        }
        else
        {
            // Reset the color when not blinking
            ren.material.color = StartColor;
        }
    }

    private IEnumerator SpawnAndAskForNeeds()
    {
        // Wait for the specified spawn time
        yield return new WaitForSeconds(spawnTime);

        // Start blinking when asking for a request
        isBlinking = true;

        // Ask for needs after spawn time
        StartCoroutine(AskForNeeds());
    }

    private IEnumerator AskForNeeds()
    {
        if (radioController == null || acController == null || pedalsController == null || windowButtonsController == null || uiText == null)
        {
            Debug.LogError("One or more references in NPCController are not assigned!");
            yield break; // Exit the coroutine early to prevent further errors
        }

        string[] needs = GetRandomNeeds();
        DisplayDialogue($"I need the {needs[0]} and {needs[1]}. Please help!");
        yield return WaitForInteractions(needs);
        bool needsSatisfied = CheckNeedsSatisfied(needs);

        if (needsSatisfied)
        {
            DisplayDialogue("Thank you! My needs are satisfied.");
        }
        else
        {
            DisplayDialogue("You didn't satisfy my needs. Try again next time.");
        }

        // Stop blinking after asking for needs
        isBlinking = false;

        // Wait for 5 seconds before making the UI disappear
        yield return new WaitForSeconds(5f);

        // Reset the UI Text component
        uiText.text = "";
    }

    private string[] GetRandomNeeds()
    {
        string[] allNeeds = { "radio", "AC", "pedals", "window buttons" };
        for (int i = 0; i < allNeeds.Length; i++)
        {
            int randomIndex = Random.Range(i, allNeeds.Length);
            string temp = allNeeds[i];
            allNeeds[i] = allNeeds[randomIndex];
            allNeeds[randomIndex] = temp;
        }
        string[] randomNeeds = { allNeeds[0], allNeeds[1] };
        return randomNeeds;
    }

    private void DisplayDialogue(string message)
    {
        if (uiText != null)
        {
            uiText.text = $"{message}";
        }
        else
        {
            Debug.LogWarning("UI Text is not assigned to the NPC!");
        }
    }

    private IEnumerator ResetUITextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        uiText.text = "";
    }

    private IEnumerator WaitForInteractions(string[] needs)
    {
        // Implement your logic for waiting for player interactions
        // For simplicity, let's wait for 5 seconds (replace this with your actual logic)
        yield return new WaitForSeconds(10f);
    }

    private bool CheckNeedsSatisfied(string[] needs)
    {
        foreach (string need in needs)
        {
            switch (need)
            {
                case "radio":
                    if (!radioController.IsOn())
                        return false;
                    break;
                case "AC":
                    if (!acController.IsOn())
                        return false;
                    break;
                case "pedals":
                    if (!pedalsController.IsPressed())
                        return false;
                    break;
                case "window buttons":
                    if (!windowButtonsController.IsOpen())
                        return false;
                    break;
            }
        }
        return true;
    }
}








