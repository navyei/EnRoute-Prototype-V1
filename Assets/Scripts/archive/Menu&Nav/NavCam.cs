using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 2f;

    private void Update()
    {
        // Move the camera using WASD keys
        MoveCamera();

        // Rotate the camera when right mouse button is held down
        RotateCamera();
    }

    void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Only move along the X and Z axes
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    void RotateCamera()
    {
        if (Input.GetMouseButton(1)) // Right mouse button is held down
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 rotation = new Vector3(-mouseY, mouseX, 0f) * rotationSpeed;
            transform.Rotate(rotation);
        }
    }
}
