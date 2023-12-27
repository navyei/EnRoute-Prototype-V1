using UnityEngine;

public class WhatChaLookingAt : MonoBehaviour
{
    private Transform ThingToLookAt;

    private void Start()
    {
        ThingToLookAt = GameObject.FindGameObjectWithTag("Aim Target").transform;
    }

    void FixedUpdate()
    {
        transform.LookAt(ThingToLookAt.transform.position);
    }
}
