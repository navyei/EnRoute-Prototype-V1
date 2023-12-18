using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarPosition : MonoBehaviour
{
    void Start()
    {
        // Load the car position when the object is created (e.g., when returning to the scene)
        LoadPosition();
    }

    void LoadPosition()
    {
        // Load the car's position from PlayerPrefs
        float carPosX = PlayerPrefs.GetFloat("CarPosX");
        float carPosY = PlayerPrefs.GetFloat("CarPosY");
        float carPosZ = PlayerPrefs.GetFloat("CarPosZ");

        // Set the car's position
        //Crazy I said
        if (transform != null)
        {
            transform.position = new Vector3(carPosX, carPosY, carPosZ);
        }
    }
}

