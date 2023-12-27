using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public GameObject[] NPCInStation;
    public GameObject VehiclesLeaving;

    public void LeaveStation()
    {
        FindObjectOfType<GameManager>().NextCamera();
        VehiclesLeaving.SetActive(true);
    }
}
