using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject fragmentPrefab;
    public int numberOfFragments = 10;
    public float explosionForce = 50f;

    void Start()
    {
        TriggerExplosion();
    }

    void TriggerExplosion()
    {
        for (int i = 0; i < numberOfFragments; i++)
        {
            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Random.rotation);
            Rigidbody rb = fragment.GetComponent<Rigidbody>();
            rb.AddExplosionForce(explosionForce, transform.position, 5f);
        }
        Destroy(gameObject);
    }
}