using UnityEngine;

public class VehicleDragNDrop : MonoBehaviour
{
    public int LayerNumber;
    public int Height;
    public int GridSize;
    public LayerMask Target;

    public bool Hovering { get; private set; }
    private bool LayerApplied;
    private void Update()
    {
        if (!LayerApplied)
        {
            gameObject.layer = LayerNumber;
            LayerApplied = true;
        }
        if (MouseHover())
        {
            Hovering = true;
        }
        else if (Input.GetKey(KeyCode.Mouse0) && Hovering)
        {
            Dragging();
        }
        else if (!Input.GetKey(KeyCode.Mouse0))
        {
            Hovering = false;
            GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
        }

    }

    private bool MouseHover()
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
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            Vector3 OutputPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            float GridX = Mathf.Round(OutputPos.x / GridSize) * GridSize;
            float GridZ = Mathf.Round(OutputPos.z / GridSize) * GridSize;
            GetComponent<Rigidbody>().MovePosition(new Vector3(GridX, OutputPos.y + Height, GridZ));
        }
    }
}