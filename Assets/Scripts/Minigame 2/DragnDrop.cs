using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragging = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }  

    void OnMouseDown()
    {
        isDragging = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
        rb.isKinematic = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                rb.MovePosition(targetPosition);
            }
        }
    }
}








