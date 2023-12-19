using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCleanup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != this.gameObject)
        {
            Debug.Log("Destroying object: " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}