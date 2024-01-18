using UnityEngine;

public class CarController : MonoBehaviour
{
    public float motorTorque = 2000;
    public float brakeTorque = 2000;
    public float maxSpeed = 20;
    public float steeringRange = 30;
    public float steeringRangeAtMaxSpeed = 10;
    public float centreOfGravityOffset = -1f;

    private GameObject currentCustomer;

    WheelControl[] wheels;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.centerOfMass += Vector3.up * centreOfGravityOffset;
        wheels = GetComponentsInChildren<WheelControl>();
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
        float vInput = Input.GetAxis("Vertical");
        float hInput = Input.GetAxis("Horizontal");
        if (IsCarActive())
        {
            float forwardSpeed = Vector3.Dot(transform.forward, rigidBody.velocity);
            float speedFactor = Mathf.InverseLerp(0, maxSpeed, forwardSpeed);
            float currentMotorTorque = Mathf.Lerp(motorTorque, 0, speedFactor);
            float currentSteerRange = Mathf.Lerp(steeringRange, steeringRangeAtMaxSpeed, speedFactor);
            bool isAccelerating = Mathf.Sign(vInput) == Mathf.Sign(forwardSpeed);

            foreach (var wheel in wheels)
            {
                if (wheel.steerable)
                {
                    wheel.WheelCollider.steerAngle = hInput * currentSteerRange;
                }

                if (isAccelerating)
                {
                    if (wheel.motorized)
                    {
                        wheel.WheelCollider.motorTorque = vInput * currentMotorTorque;
                    }
                    wheel.WheelCollider.brakeTorque = 0;
                }
                else
                {
                    wheel.WheelCollider.brakeTorque = Mathf.Abs(vInput) * brakeTorque;
                    wheel.WheelCollider.motorTorque = 0;
                }
            }
        }
    }
}
