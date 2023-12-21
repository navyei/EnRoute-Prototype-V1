using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public DynamicLineDrawer lineDrawer; // Reference to the script that draws the line
    public float speed = 5f; // Speed of movement
    public float heightAbovePlane = 1f; // Adjust this value to set the height above the plane
    public float rotationSpeed = 10f; // Adjust this value to set the rotation speed


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

            // Calculate the total length of the line
            float totalLineLength = 0f;
            for (int i = 1; i < lineRenderer.positionCount; i++)
            {
                totalLineLength += Vector3.Distance(lineRenderer.GetPosition(i - 1), lineRenderer.GetPosition(i));
            }

            // Move the object along the line based on the speed
            distanceAlongLine += (Time.deltaTime * speed) / totalLineLength;

            // If the object has reached the end of the line, stop moving
            if (distanceAlongLine >= 1f)
            {
                distanceAlongLine = 1f;
                // Optionally, you can perform additional actions when the object reaches the end of the line
            }

            // Interpolate along the line and set the object's position
            Vector3 newPosition = InterpolatePositionAlongLine(distanceAlongLine, lineRenderer);
            newPosition.y = heightAbovePlane;
            transform.position = newPosition;

            // Calculate the tangent direction
            Vector3 tangent = InterpolateTangentAlongLine(distanceAlongLine, lineRenderer);

            // Rotate the object to align with the line direction
            if (tangent != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(tangent, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }

    Vector3 InterpolatePositionAlongLine(float t, LineRenderer lineRenderer)
    {
        float totalLineLength = 0f;
        for (int i = 1; i < lineRenderer.positionCount; i++)
        {
            totalLineLength += Vector3.Distance(lineRenderer.GetPosition(i - 1), lineRenderer.GetPosition(i));
        }

        float targetDistance = t * totalLineLength;

        float currentDistance = 0f;
        for (int i = 1; i < lineRenderer.positionCount; i++)
        {
            float segmentLength = Vector3.Distance(lineRenderer.GetPosition(i - 1), lineRenderer.GetPosition(i));
            if (currentDistance + segmentLength >= targetDistance)
            {
                float remainingDistance = targetDistance - currentDistance;
                float ratio = remainingDistance / segmentLength;
                return Vector3.Lerp(lineRenderer.GetPosition(i - 1), lineRenderer.GetPosition(i), ratio);
            }
            currentDistance += segmentLength;
        }

        // If something goes wrong, return the last point
        return lineRenderer.GetPosition(lineRenderer.positionCount - 1);
    }

    Vector3 InterpolateTangentAlongLine(float t, LineRenderer lineRenderer)
    {
        float totalLineLength = 0f;
        for (int i = 1; i < lineRenderer.positionCount; i++)
        {
            totalLineLength += Vector3.Distance(lineRenderer.GetPosition(i - 1), lineRenderer.GetPosition(i));
        }

        float targetDistance = t * totalLineLength;

        float currentDistance = 0f;
        for (int i = 1; i < lineRenderer.positionCount; i++)
        {
            float segmentLength = Vector3.Distance(lineRenderer.GetPosition(i - 1), lineRenderer.GetPosition(i));
            if (currentDistance + segmentLength >= targetDistance)
            {
                float remainingDistance = targetDistance - currentDistance;
                float ratio = remainingDistance / segmentLength;
                return (lineRenderer.GetPosition(i) - lineRenderer.GetPosition(i - 1)).normalized;
            }
            currentDistance += segmentLength;
        }

        // If something goes wrong, return the zero vector
        return Vector3.zero;
    }

}


















