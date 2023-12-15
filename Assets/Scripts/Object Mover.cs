using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public DynamicLineDrawer lineDrawer; // Reference to the script that draws the line
    public float speed = 5f; // Speed of movement
    public float heightAbovePlane = 1f; // Adjust this value to set the height above the plane

    private float distanceAlongLine = 0f;
    private bool lineDrawn = false;

    void Update()
    {
        if (lineDrawn)
        {
            MoveObjectAlongLine();
        }
        else
        {
            CheckForClickOnFinish();
        }
    }

    void CheckForClickOnFinish()
    {
        // Check for mouse click on object with the 'Finish' tag
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Finish"))
            {
                lineDrawn = true;
                // Optionally, you can perform additional actions when the object reaches the end of the line
            }
        }
    }

    void MoveObjectAlongLine()
    {
        if (lineDrawer != null && lineDrawer.lineRenderer != null)
        {
            LineRenderer lineRenderer = lineDrawer.lineRenderer;

            // Move the object along the line based on the speed
            distanceAlongLine += Time.deltaTime * speed;

            // If the object has reached the end of the line, stop moving
            if (distanceAlongLine > lineRenderer.positionCount - 1)
            {
                distanceAlongLine = lineRenderer.positionCount - 1;
            }

            // Interpolate along the line and set the object's position
            int floorIndex = Mathf.FloorToInt(distanceAlongLine);
            int ceilIndex = Mathf.CeilToInt(distanceAlongLine);

            // Ensure indices are within bounds
            floorIndex = Mathf.Clamp(floorIndex, 0, lineRenderer.positionCount - 1);
            ceilIndex = Mathf.Clamp(ceilIndex, 0, lineRenderer.positionCount - 1);

            Vector3 floorPosition = lineRenderer.GetPosition(floorIndex);
            Vector3 ceilPosition = lineRenderer.GetPosition(ceilIndex);

            // Interpolate between the two adjacent points
            float t = distanceAlongLine - floorIndex;
            Vector3 newPosition = Vector3.Lerp(floorPosition, ceilPosition, t);

            // Adjust the y-coordinate to keep the object above the plane
            newPosition.y = heightAbovePlane;

            transform.position = newPosition;

            // Optionally, rotate the object to align with the line direction
            Vector3 direction = ceilPosition - floorPosition;
            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}

















