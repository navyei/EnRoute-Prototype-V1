using UnityEngine;

public class SaveCarPosition : MonoBehaviour
{
    void OnDestroy()
    {
        // Save the car position when the object is destroyed (e.g., when changing scenes)
        SavePosition();
    }

    void SavePosition()
    {
        // Save the car's position to PlayerPrefs
        PlayerPrefs.SetFloat("CarPosX", transform.position.x);
        PlayerPrefs.SetFloat("CarPosY", transform.position.y);
        PlayerPrefs.SetFloat("CarPosZ", transform.position.z);
        PlayerPrefs.Save();
    }
}

