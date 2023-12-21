using UnityEngine;

public class color : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color32(50, 50, 50, 255);

    }

    // Update is called once per frame
    void Update()
    {

    }
}

