using UnityEngine;

public class ButtonSpawn : MonoBehaviour
{
    public bool Input = false;
    public GameObject BaseVehicle;
    public GameObject SpawnVehicle;

    private Vector3 BasePosition;
    private Quaternion BaseRotation;
    void Start()
    {
        BasePosition = BaseVehicle.transform.position;
        BaseRotation = BaseVehicle.transform.rotation;
        Destroy(BaseVehicle);
    }
    private void FixedUpdate()
    {
        if (Input)
        {
            GameObject SpawnedVehicle = Instantiate(SpawnVehicle, BasePosition, BaseRotation);
        }
        Input = false;
    }

    public void Pressed()
    {
        Input = true;

    }
}
