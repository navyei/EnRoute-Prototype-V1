using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float cameraSmoothing = 1.0f;
    public float LookUpmax = 60f;
    public float LookUpmin = -60f;
    public float LookLeftmax = -60f;
    public float LookRightmax = 60f;
    public float raycastDistance = 5f;  // Adjust the raycast distance as needed

    // Expose the current rotation values
    public float CurrentRotationX { get; private set; }
    public float CurrentRotationY { get; private set; }

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        CurrentRotationX = transform.localRotation.eulerAngles.x;
        CurrentRotationY = transform.localRotation.eulerAngles.y;
    }

    void Update()
    {
        // Adjust the rotation based on mouse input
        CurrentRotationX += Input.GetAxis("Mouse Y") * cameraSmoothing * (-1);
        CurrentRotationY += Input.GetAxis("Mouse X") * cameraSmoothing;

        // Clamp the vertical rotation to limit looking up and down
        CurrentRotationX = Mathf.Clamp(CurrentRotationX, LookUpmin, LookUpmax);

        // Clamp the horizontal rotation to limit looking left and right
        CurrentRotationY = Mathf.Clamp(CurrentRotationY, LookLeftmax, LookRightmax);

        // Apply the rotation to the player's transform
        transform.localRotation = Quaternion.Euler(CurrentRotationX, CurrentRotationY, transform.localRotation.eulerAngles.z);

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteractWithObject();
        }
    }

    void TryInteractWithObject()
    {
        RaycastHit hit;
        Vector3 raycastDirection = transform.forward;

        // Perform raycasting to see if there is an interactive object in front of the player
        if (Physics.Raycast(transform.position, raycastDirection, out hit, raycastDistance))
        {
            // Check if the hit object has an InteractiveObject script
            InteractiveObject interactiveObject = hit.collider.GetComponent<InteractiveObject>();

            // If an InteractiveObject script is found, attempt to interact with it
            if (interactiveObject != null)
            {
                interactiveObject.Interact();
            }
        }
    }
}

