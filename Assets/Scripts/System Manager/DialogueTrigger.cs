using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;
    public Color HoverColor;
    public GameObject TalkIndicator;

    private Color OriginalColor;
    private bool IsPressed = false;

    private void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
        TalkIndicator.SetActive(false);
        StartCoroutine(WaitToTalk());
    }

    private void Update()
    {
        if (MouseHover())
        {
            GetComponent<SpriteRenderer>().color = HoverColor;
            if (MouseHover() && Input.GetKey(KeyCode.Mouse0) && TalkIndicator.activeSelf)
            {
                GetComponent<SpriteRenderer>().color = OriginalColor;
                TriggerDialogue();
            }
        }
        else GetComponent<SpriteRenderer>().color = OriginalColor;
    }

    IEnumerator WaitToTalk()
    {
        yield return new WaitForSeconds(2f);
        TalkIndicator.SetActive(true);
    }

    public void ButtonInput()
    {
        IsPressed = true;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }

    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2) && Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }
}