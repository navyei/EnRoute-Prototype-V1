using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public bool IsNPC;
    public GameObject DialogueIndicator;
    public float IndicatorCooldown = 5f;
    public bool FinishDialogue;
    public GameObject AfterDialogueTarget;
    public Color HoverColor;

    private Color OriginalColor;
    private bool InDialogue;

    private void Start()
    {
        if (IsNPC)
        {
            OriginalColor = GetComponent<SpriteRenderer>().color;
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
                }
            }
            else GetComponent<SpriteRenderer>().color = OriginalColor;
        }
        if (FinishDialogue)
        {
            transform.position = Vector3.Lerp(transform.position, AfterDialogueTarget.transform.position, 0.1f);
        }
    }
    public void TriggerDialogue()
    {
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

    private List<GameObject> GOs = new List<GameObject>();
    private void OnTriggerStay(Collider other)
    {
        if (!GOs.Contains(other.gameObject))
        {
            GOs.Add(other.gameObject);
            MoveToCity();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (GOs.Contains(other.gameObject))
        {
            GOs.Remove(other.gameObject);
        }
    }

    void MoveToCity()
    {
        if (GOs.Count >= 2)
        {
            GameObject GO1 = GOs[0];
            GameObject GO2 = GOs[1];
            if (GO1.layer == 6 || GO1.layer == 7 || GO2.layer == 6 || GO2.layer == 7)
            {
                GameObject.Destroy(GO1);
                GameObject.Destroy(GO2);
            }
        }
    }

}