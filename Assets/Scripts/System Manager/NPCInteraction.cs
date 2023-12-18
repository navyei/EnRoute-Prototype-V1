using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class NPCInteraction : MonoBehaviour
{
    public float GridSize;
    public Color HoverColor;
    public LayerMask Ignore;
    public float Timer;
    public GameObject TalkIndicator;

    private bool WantsToTalk = false;
    private Color OriginalColor;

    private void Start()
    {
        OriginalColor = GetComponent<SpriteRenderer>().color;
        TalkIndicator.SetActive(false);
    }

    private void Update()
    {
        WaitToTalk();
        if (MouseHover())
        {
            GetComponent<SpriteRenderer>().color = HoverColor;

            if (Input.GetKey(KeyCode.Mouse0) && WantsToTalk)
            {
                
            }
            else GetComponent<SpriteRenderer>().color = OriginalColor;
        }
    }
    IEnumerator WaitToTalk()
    {
        yield return new WaitForSeconds(2f);
        TalkIndicator.SetActive(true);
        WantsToTalk = true;
    }

    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return !Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse2) && Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }
    
}