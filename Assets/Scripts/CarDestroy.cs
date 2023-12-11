using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDestroy : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
       
    }
    private void OnColissionEnter2D(Collider2D collission)
    
        {
           Destroy(gameObject);
           PauseGame();
        }
    
    
   
}
