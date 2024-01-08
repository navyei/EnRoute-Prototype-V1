using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public GameObject[] frontWheels;
    public GameObject[] backWheels;

    private Rigidbody rb;
    private Vector3[] frontWheelPos;
    private Vector3[] backWheelPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        frontWheelPos = new Vector3[frontWheels.Length];
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheelPos[i] = frontWheels[i].transform.localPosition;
        }
        backWheelPos = new Vector3[backWheels.Length];
        for (int i = 0; i < backWheels.Length; i++)
        {
            backWheelPos[i] = backWheels[i].transform.localPosition;
        }
    }

    private void Update()
    {
        if (IsCarActive())
        {
            HandleCarMovement();
        }
    }

    bool IsCarActive()
    {
        // Add any additional conditions to check if the car should be active
        return enabled;
    }

    void HandleCarMovement()
    {
        float verti = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");

        // Adds gravity
        rb.AddForce(0f, Physics.gravity.y * Time.deltaTime, 0f);
        foreach (var wheel in frontWheels)
        {
            wheel.GetComponent<Rigidbody>().AddForce(0f, Physics.gravity.y * Time.deltaTime, 0f);
        }
        foreach (var wheel in backWheels)
        {
            wheel.GetComponent<Rigidbody>().AddForce(0f, Physics.gravity.y * Time.deltaTime, 0f);
        }

        // Adds force to wheels only if the script is active
        if (IsCarActive())
        {
            Vector3 speed = transform.rotation * new Vector3(0f, Physics.gravity.y * Time.deltaTime, verti * moveSpeed * Time.deltaTime);
            foreach (var wheel in backWheels)
            {
                wheel.GetComponent<Rigidbody>().AddForce(speed);
            }
            foreach (var wheel in frontWheels)
            {
                Vector3 frontSpeed = wheel.transform.localRotation * speed;
                wheel.GetComponent<Rigidbody>().AddForce(frontSpeed);
            }
        }

        // Rotates wheels
        float rotate = hori * rotateSpeed * 10 * Time.deltaTime;
        foreach (var wheel in frontWheels)
        {
            wheel.transform.Rotate(Vector3.up, rotate);
            Quaternion currentRotation = wheel.transform.localRotation;
            Quaternion newRotation = Quaternion.Euler(0f, Mathf.Clamp(Mathf.DeltaAngle(0, currentRotation.eulerAngles.y), -50f, 50f), 0f);
            wheel.transform.localRotation = newRotation;
        }
        foreach (var wheel in backWheels)
        {
            wheel.transform.rotation = transform.rotation;
        }

        // Keeping front wheels in place
        for (int i = 0; i < frontWheels.Length; i++)
        {
            frontWheels[i].transform.localPosition = frontWheelPos[i];
        }
        for (int i = 0; i < backWheels.Length; i++)
        {
            backWheels[i].transform.localPosition = backWheelPos[i];
        }
        //Debug.Log(rb.velocity.magnitude);
    }
}
