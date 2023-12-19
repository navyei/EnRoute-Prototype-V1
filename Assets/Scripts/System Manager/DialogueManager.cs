using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro.EditorUtilities;

public class DialogueManager : MonoBehaviour
{
    public TMPro.TMP_Text Name;
    public TMPro.TMP_Text Dialogue;
    public GameObject DialoguePopup;
    public Queue<string> Sentences;
    public Animator Animator;
    void Start()
    {
        Sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue Dialogue)
    {
        Name.text = Dialogue.Name;
        Animator.SetBool("Talking", true);
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(Sentence));
    }

    IEnumerator TypeSentence(string Sentence)
    {
        Dialogue.text = "";
        foreach (char letter in Sentence.ToCharArray())
        {
            Dialogue.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Animator.SetBool("Talking", false);
    }
}
