using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public Camera raycastCamera; // Public variable to assign the camera in the Unity Editor
    protected Renderer rend;
    protected bool isLookingAtObject = false;

    protected virtual void Start()
    {
        rend = GetComponent<Renderer>();
    }

    protected virtual void Update()
    {
        // Pass the assigned camera to the CheckLookAtObject method
        CheckLookAtObject(raycastCamera);
    }

    // Modify the method to accept a camera parameter
    protected virtual void CheckLookAtObject(Camera assignedCamera)
    {
        if (rend != null && assignedCamera != null)
        {
            // Calculate the center of the screen
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

            // Create a ray from the assigned camera through the center of the screen
            Ray ray = assignedCamera.ScreenPointToRay(screenCenter);

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



