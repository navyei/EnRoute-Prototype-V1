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
    public Animator PopupAnimator;
    public bool TriggerAdded;
    void Start()
    {
        Sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue Dialogue)
    {
        DialoguePopup.SetActive(true);
        Name.text = Dialogue.Name;
        PopupAnimator.SetBool("Talking", true);
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

    public void EndDialogue()
    {
        if (!TriggerAdded)
        {
            TriggerScript[] TargetScript = FindObjectsOfType<TriggerScript>();
            foreach (TriggerScript script in TargetScript)
            {
                script.IndicatorOff();
            }
            TriggerAdded = true;
        }
        PopupAnimator.SetBool("Talking", false);
        StartCoroutine(SetPopupInactive());
    }

    IEnumerator SetPopupInactive()
    {
        yield return new WaitForSeconds(0.5f);
        DialoguePopup.SetActive(false);
    }
}
