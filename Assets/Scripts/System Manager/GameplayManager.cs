using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject[] NPCs;
    public GameObject[] NPCSpawners;

    private void FixedUpdate()
    {
        NPCs = GameObject.FindGameObjectsWithTag("NPC");
    }
}
