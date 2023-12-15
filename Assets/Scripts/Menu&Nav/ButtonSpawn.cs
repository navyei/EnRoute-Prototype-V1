using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject BaseCar;
    public GameObject SpawnCar;
    
    private Transform BasePos;
    private bool Input = false;
    private Vector3 SpawnPos;
    private Quaternion SpawnRot;
    private void Start()
    {
        BasePos = BaseCar.transform;
        SpawnPos = BasePos.position;
        SpawnRot = BasePos.rotation;
        Destroy( BaseCar );
    }

    public void Pressed()
    {
        Input = true;
    }
    private void Update()
    {
        if (Input)
        {
            GameObject SpawnedCar = Instantiate(SpawnCar, SpawnPos, SpawnRot);
        }
        Input = false;
    }
}
