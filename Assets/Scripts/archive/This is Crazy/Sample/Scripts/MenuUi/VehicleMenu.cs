using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VehicleMenu : MonoBehaviour
{
    private NPCController npcController;

    public void SetNPCController(NPCController npcController)
    {
        this.npcController = npcController;
    }

    public void OnVehicleButtonClick(string vehicleType)
    {
        if (npcController != null)
        {
            npcController.RequestVehicleSpawn(vehicleType);
        }

        StartCoroutine(DestroyMenu());
    }

    private IEnumerator DestroyMenu()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}








