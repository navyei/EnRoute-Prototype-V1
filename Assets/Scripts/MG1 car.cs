using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG1car : MonoBehaviour
{
    // Start is called before the first frame update
    float moveSpeed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movePlayer = Input.GetAxis("Horizontal");
        transform.Translate(movePlayer*moveSpeed*Time.deltaTime,0f,0f);
    }
}
