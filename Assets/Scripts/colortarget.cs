using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colortarget : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         gameObject.GetComponent<Renderer>().material.color = new Color32(255,0,0,255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
