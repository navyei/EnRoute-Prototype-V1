using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue Dialogue;
    public Color HoverColor;

    private Color OriginalColor;

    private void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(Dialogue);
    }
    private void Update()
    {
        if (MouseHover())
        {
            GetComponent<SpriteRenderer>().color = HoverColor;
        }
        else GetComponent<SpriteRenderer>().color = OriginalColor;
    }

    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2) && Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }
}