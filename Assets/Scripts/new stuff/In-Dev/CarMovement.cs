using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 5f;
    public GameObject steeringWheel;
    public GameObject[] frontWheels;
    public GameObject[] backWheels;

    private GameObject currentCustomer;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentCustomer != null)
            {
                DropOffCustomer();
            }
            else
            {
                PickUpCustomer();
            }
        }
    }

    void PickUpCustomer()
    {
        // Adjust the parameters of Physics.OverlapSphere to match your scene
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Customer"));

        if (colliders.Length > 0)
        {
            currentCustomer = colliders[0].gameObject;
            currentCustomer.SetActive(false);
            Debug.Log("Picked up customer!");
        }
    }


    void DropOffCustomer()
    {
        if (currentCustomer != null)
        {
            // Replace this with your logic for dropping off the customer.
            // For simplicity, we just set the customer's position to the car's position.
            currentCustomer.SetActive(true);
            currentCustomer.transform.position = transform.position;
            currentCustomer = null;
            Debug.Log("Dropped off customer!");
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
        steeringWheel.transform.Rotate(Vector3.right, rotate);
        Quaternion steerRotation = Quaternion.Euler(0f, 0f, Mathf.Clamp(Mathf.DeltaAngle(0, steeringWheel.transform.localRotation.eulerAngles.z), -50f, 50f));
        steeringWheel.transform.localRotation = steerRotation;
        foreach (var wheel in frontWheels)
        {
            wheel.transform.Rotate(Vector3.up, rotate);
            Quaternion newRotation = Quaternion.Euler(0f, Mathf.Clamp(Mathf.DeltaAngle(0, wheel.transform.localRotation.eulerAngles.y), -50f, 50f), 0f);
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
