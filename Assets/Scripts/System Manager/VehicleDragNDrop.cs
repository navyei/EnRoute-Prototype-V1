using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class VehicleDragNDrop : MonoBehaviour
{
    public int Height;
    public int GridSize;
    public LayerMask Target;

    public bool Hovering;

    private void Update()
    {
        if (MouseHover())
        {
            Hovering = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Hovering = false;
        }
        if (Input.GetKey(KeyCode.Mouse0) && Hovering)
        {
            Dragging();
        }
    }

    bool MouseHover()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.collider.name == name;
    }

    void Dragging()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Target))
        {
            Vector3 OutputPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            float GridX = Mathf.Round(OutputPos.x / GridSize) * GridSize;
            float GridZ = Mathf.Round(OutputPos.z / GridSize) * GridSize;
            GetComponent<Rigidbody>().position = new Vector3(GridX, OutputPos.y + Height, GridZ);
        }
    }
}