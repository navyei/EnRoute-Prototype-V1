using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if collided with an object tagged as "Destroy"
        if (collision.gameObject.CompareTag("Destroy"))
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }
}
