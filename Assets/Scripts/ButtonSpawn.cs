using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawn : MonoBehaviour
{
    public GameObject BaseCar;
    public GameObject SpawnCar;

    private Transform BasePos;
    private Vector3 SpawnPos;

    private void Start()
    {
        BasePos = BaseCar.transform;
        Destroy(BaseCar);
    }
    private void FixedUpdate()
    {
        
    }
}
