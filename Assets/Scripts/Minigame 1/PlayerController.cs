using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5.0f;

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move the player horizontally
        transform.Translate(Vector3.right * horizontalInput * movementSpeed * Time.deltaTime);
    }
}
