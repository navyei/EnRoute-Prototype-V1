using UnityEngine;
public class SceneMover : MonoBehaviour
{
    public float maxMoveSpeed = 10f;
    private float currentSpeed = 0f;
    public float acceleration = 10f;
    public float deceleration = 10f;

    public float leftBoundary = -15f;
    public float rightBoundary = 20f;

    void Update()
    {
        float targetSpeed = 0f;
        if (Input.GetKey(KeyCode.A) && transform.position.x > leftBoundary)
        {
            targetSpeed = -maxMoveSpeed;
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < rightBoundary)
        {
            targetSpeed = maxMoveSpeed;
        }

        if (currentSpeed < targetSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Min(currentSpeed, targetSpeed);
        }
        else if (currentSpeed > targetSpeed)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            currentSpeed = Mathf.Max(currentSpeed, targetSpeed);
        }

        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime, Space.World);

        // Debug output
        Debug.Log($"Position: {transform.position.x}, Left Boundary: {leftBoundary}, Right Boundary: {rightBoundary}");
    }
}



