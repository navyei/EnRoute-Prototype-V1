using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    protected Renderer rend;
    protected bool isLookingAtObject = false;

    protected virtual void Start()
    {
        rend = GetComponent<Renderer>();
    }

    protected virtual void Update()
    {
        CheckLookAtObject();
    }

    protected virtual void CheckLookAtObject()
    {
        if (rend != null)
        {
            // Calculate the center of the screen
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // Create a ray from the camera through the center of the screen
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                SetGlow(true);
                isLookingAtObject = true;
            }
            else
            {
                SetGlow(false);
                isLookingAtObject = false;
            }
        }
    }

    private void SetGlow(bool shouldGlow)
    {
        if (rend != null)
        {
            Material material = rend.material;

            // Set emission color to green
            Color emissionColor = shouldGlow ? Color.green : Color.black;

            material.SetColor("_EmissionColor", emissionColor);

            // Enable or disable emission based on whether the object is being looked at
            material.EnableKeyword(shouldGlow ? "_EMISSION" : "_EMISSION_OFF");
        }
    }

    public virtual void Interact()
    {
        // Implement your generic interaction logic here
    }
}

