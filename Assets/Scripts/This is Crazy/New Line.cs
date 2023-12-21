using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLineDrawer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject finishObject;
    public float connectThreshold = 0.5f; // Adjust the threshold as needed

    private bool isDrawing = false;
    private List<Vector3> linePoints = new List<Vector3>();
    private bool canDrawOnPath = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsMouseOverStartObject())
            {
                StartDrawing();
            }
            else if (isDrawing)
            {
                ContinueDrawing();
            }
            else if (IsMouseOverFinishObject())
            {
                ConnectToFinish();
            }
        }
    }

    void StartDrawing()
    {
        isDrawing = true;
        lineRenderer.positionCount = 1;
        linePoints.Clear();
        linePoints.Add(GetMousePositionOnPlane());
        lineRenderer.SetPosition(0, linePoints[0]);
        canDrawOnPath = true;
    }

    void ContinueDrawing()
    {
        Vector3 currentMousePosition = GetMousePositionOnPlane();

        // Check for collision with objects tagged as "building" only when actively drawing
        if (CheckCollisionWithBuilding(linePoints[linePoints.Count - 1], currentMousePosition))
        {
            // Don't draw if there's a collision with the building
            canDrawOnPath = false;
        }
        else
        { canDrawOnPath |= true; }

        if (canDrawOnPath)
        {
            linePoints.Add(currentMousePosition);

            int currentPositionCount = linePoints.Count;
            lineRenderer.positionCount = currentPositionCount;

            for (int i = 0; i < currentPositionCount; i++)
            {
                lineRenderer.SetPosition(i, linePoints[i]);
            }
        }
    }

    void ConnectToFinish()
    {
        if (isDrawing && linePoints.Count > 1)
        {
            Vector3 finishObjectPosition = finishObject.transform.position;

            // Connect the line to the finish object
            linePoints.Add(finishObjectPosition);

            int currentPositionCount = linePoints.Count;
            lineRenderer.positionCount = currentPositionCount;

            for (int i = 0; i < currentPositionCount; i++)
            {
                lineRenderer.SetPosition(i, linePoints[i]);
            }

            isDrawing = false;
            Debug.Log("Drawing stopped. Line connected to Finish object!");
        }
    }

    bool IsMouseOverStartObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Start");
    }

    bool IsMouseOverFinishObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == finishObject && hit.collider.gameObject.CompareTag("Finish");
    }

    bool CheckCollisionWithBuilding(Vector3 startPoint, Vector3 endPoint)
    {
        Ray ray = new Ray(startPoint, endPoint - startPoint);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Vector3.Distance(startPoint, endPoint)))
        {
            if (hit.collider.CompareTag("Building"))
            {
                // If the hit object is a building, stop drawing only for this segment
                canDrawOnPath = false;
                return true;
            }
        }

        return false;
    }

    Vector3 GetMousePositionOnPlane()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            return ray.GetPoint(distance);
        }

        // If the ray doesn't hit the plane, return the current mouse position without modifying it
        return ray.origin + ray.direction * distance;
    }
}