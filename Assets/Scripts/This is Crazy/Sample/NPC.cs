using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    private Dictionary<string, bool> npcNeeds = new Dictionary<string, bool>();
    private bool needsChosen = false;

    // Add a reference to your dialogue UI element
    public Text dialogueText;

    void Start()
    {
        // Initialize random needs for each NPC
        InitializeRandomNeeds();
    }

    void Update()
    {
        if (!needsChosen)
        {
            // Check and address needs
            foreach (var need in npcNeeds)
            {
                if (need.Value)
                {
                    HandleNeed(need.Key);
                }
            }
        }
    }

    void InitializeRandomNeeds()
    {
        // Define the possible needs
        string[] possibleNeeds = { "Radio", "AC", "Pedals", "WindowButton" };

        // Set all needs to false initially
        foreach (var need in possibleNeeds)
        {
            npcNeeds[need] = false;
        }

        // Shuffle the array to get random needs
        System.Random rng = new System.Random();
        int n = possibleNeeds.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = possibleNeeds[k];
            possibleNeeds[k] = possibleNeeds[n];
            possibleNeeds[n] = value;
        }

        // Select the first two needs from the shuffled array
        for (int i = 0; i < 2; i++)
        {
            npcNeeds[possibleNeeds[i]] = true;
        }

        // Indicate that needs have been chosen
        needsChosen = true;

        // Display dialogue
        DisplayDialogue("My needs are: " + string.Join(", ", npcNeeds.Keys));
    }

    void HandleNeed(string need)
    {
        // Implement logic to satisfy the specific need
        switch (need)
        {
            case "Radio":
                // Implement radio handling logic
                Debug.Log("Handling Radio need");
                break;

            case "AC":
                // Implement AC handling logic
                Debug.Log("Handling AC need");
                break;

            case "Pedals":
                // Implement pedals handling logic
                Debug.Log("Handling Pedals need");
                break;

            case "WindowButton":
                // Implement window button handling logic
                Debug.Log("Handling WindowButton need");
                break;

            default:
                break;
        }

        // Mark the need as satisfied
        npcNeeds[need] = false;

        // Display dialogue
        DisplayDialogue("Thank you for satisfying my " + need + " need!");
    }

    void DisplayDialogue(string message)
    {
        // Display the dialogue on the UI
        if (dialogueText != null)
        {
            dialogueText.text = message;

            // Reset the dialogue after a delay (you can adjust the delay as needed)
            StartCoroutine(ResetDialogue(3f));
        }
    }

    IEnumerator ResetDialogue(float delay)
    {
        yield return new WaitForSeconds(delay);
        dialogueText.text = "";
    }
}
