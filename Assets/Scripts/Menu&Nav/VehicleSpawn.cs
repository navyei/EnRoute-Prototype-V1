using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawn : MonoBehaviour
{
    public int LayerNumber;
    public bool IsSpawner = false;

    private bool SettingsApplied;
    private void FixedUpdate()
    {
        if (!IsSpawner && SettingsApplied)
        {
            gameObject.layer = LayerNumber;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
            SettingsApplied = true;
        }
    }
}