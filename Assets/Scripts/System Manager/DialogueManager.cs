using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> Sentences;
    void Start()
    {
        Sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue Dialogue)
    {
        Sentences.Clear();

        foreach (string sentence in Dialogue.Sentences)
        {
            Sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string Sentence = Sentences.Dequeue();
    }
    void EndDialogue()
    {

    }
}
