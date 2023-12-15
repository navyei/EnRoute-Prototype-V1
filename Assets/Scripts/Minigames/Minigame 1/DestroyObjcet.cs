using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Check if collided with an object tagged as "Destroy"
        if (collision.gameObject.CompareTag("Destroy"))
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }
}

