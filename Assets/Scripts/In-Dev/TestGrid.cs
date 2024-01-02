using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    public GameObject[] passengers;

    private Vector3 position;
    private GameObject[] tiles;
    private BoxCollider bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        GameObject[] nextTo = 
        tiles.AddRange
    }

    private void FixedUpdate()
    {
        TickCooldown();
        foreach (GameObject a in grid)
        {
            if (a.CompareTag("Path"))
            {
                Instantiate(RandomizeNPC(), position + Vector3.up, Quaternion.identity); ;
            }
        }
    }

    IEnumerator TickCooldown()
    {
        yield return new WaitForSeconds(2f);
    }

    GameObject RandomizeNPC()
    {
        int Output = Random.Range(0, passengers.Length);
        return passengers[Output];
    }
}
