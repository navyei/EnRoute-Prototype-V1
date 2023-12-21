using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool IsNPC;
    public Dialogue Dialogue;
    public GameObject DialogueIndicator;
    public float IndicatorCooldown = 5f;
    public GameObject AfterDialogueTarget;
    public Color HoverColor;

    private Color OriginalColor;
    private bool InDialogue;
    private bool FinishDialogue;

    private void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
        if (IsNPC)
        {
            if (DialogueIndicator == null)
            {
                Debug.Log("NPC doesn't have Indicator!");
            }
            else
            {
                DialogueIndicator.SetActive(false);
                StartCoroutine(WaitToTalk());
            }
        }
    }

    private void Update()
    {
        if (IsNPC)
        {
            if (MouseHover() && !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2))
            {
                GetComponent<SpriteRenderer>().color = HoverColor;
                if (Input.GetKeyDown(KeyCode.Mouse0) && DialogueIndicator.activeSelf && !FinishDialogue)
                {
                    TriggerDialogue();
                    InDialogue = true;
                    FindObjectOfType<DialogueManager>().TriggerAdded = false;
                    FinishDialogue = true;
                }
            }
            else GetComponent<SpriteRenderer>().color = OriginalColor;
        }
        if (FinishDialogue)
        {

        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }

    IEnumerator WaitToTalk()
    {
        yield return new WaitForSecondsRealtime(IndicatorCooldown);
        DialogueIndicator.SetActive(true);
    }

    public void IndicatorOff()
    {
        if (InDialogue)
        {
            DialogueIndicator.SetActive(false);
        }
    }
}