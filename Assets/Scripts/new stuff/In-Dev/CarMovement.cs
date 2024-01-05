using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

public class CarController : MonoBehaviour
{
    public Vector3 newPosition;
    public float moveSpeed;
    public float moveTime;
    public float rotateSpeed;

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
        Vector3 speed = transform.rotation * new Vector3(0f, 0f, verti * moveSpeed * Time.deltaTime);
        speed.y = Mathf.Lerp(0f, Physics.gravity.y, Time.deltaTime);
        rb.AddForce(speed);
        float rotate = hori * rotateSpeed * 10 * Time.deltaTime;
        transform.Rotate(Vector3.up, rotate);
        Debug.Log(rb.velocity);
    }
}