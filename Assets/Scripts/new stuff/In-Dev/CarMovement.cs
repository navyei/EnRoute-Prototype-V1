using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Vector3 newPosition;
    public float moveSpeed;
    public float moveTime;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newPosition = transform.position;
    }
    private void Update()
    {
        float verti = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        if (verti >= 0)
        {
            newPosition += (transform.forward * moveSpeed);
        }
        else if (verti <= 0)
        {
            newPosition += (transform.forward * -moveSpeed);
        }
        if (hori >= 0)
        {
            newPosition += (transform.right * moveSpeed);
        }
        else if (hori <= 0)
        {
            newPosition += (transform.right * -moveSpeed);
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * moveTime);
        if (verti == 0 && hori == 0)
        {

        }
    }
}