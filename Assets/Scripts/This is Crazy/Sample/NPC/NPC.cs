using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NPCController : MonoBehaviour
{
    public RadioController radioController;
    public ACController acController;
    public PedalsController pedalsController;
    public WindowButtonController windowButtonsController;

    private void Start()
    {
        // Start asking for needs when the game begins
        StartCoroutine(AskForNeeds());
    }

    private IEnumerator AskForNeeds()
    {
        string[] needs = GetRandomNeeds();

        if (needs.Length != 2)
        {
            Debug.LogError("Error: Needs array does not contain two elements.");
            yield break; // Exit coroutine
        }

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

    private IEnumerator WaitForInteractions(string[] needs)
    {
        // Implement your logic for waiting for player interactions
        // For simplicity, let's wait until conditions are met (replace this with your actual logic)
        while (!AreInteractionsComplete())
        {
            yield return null; // Wait for the next frame
        }
    }

    private bool AreInteractionsComplete()
    {
        // Implement your logic to check if interactions are complete
        // For example, return true if the player presses a key or clicks a button
        return Input.GetKeyDown(KeyCode.Space); // Change this to your actual condition
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

    private void DisplayDialogue(string message)
    {
        // Implement your logic to display dialogue
        // For example, use UI elements to show the message
        Debug.Log(message);
    }
}



