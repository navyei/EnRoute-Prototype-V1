using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragger : MonoBehaviour
{
    private bool isDragging = false;
    private float distanceToCamera;

    void OnMouseDown()
    {
        // Calculate the distance from the camera to the object
        distanceToCamera = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Set dragging to true when the mouse is pressed over the object
        isDragging = true;
    }

    void OnMouseUp()
    {
        // Set dragging to false when the mouse is released
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Move the object to the hit point
                transform.position = hit.point + ray.direction * distanceToCamera;
            }
        }
    }
}





