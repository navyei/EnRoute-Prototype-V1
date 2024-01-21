using Cinemachine;
using UnityEngine;

public class MovingTheCam : MonoBehaviour
{
    public bool TurnEnabled;
    public bool PanEnabled;
    public float CamSpeed;

    public Camera Camera;
    public CinemachineVirtualCamera Dolly;

    private float MouseX;
    private float MouseY;
    private CinemachineOrbitalTransposer OrbTrans;

    void Start()
    {
        OrbTrans = Dolly.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }

    void Update()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");

        Vector3 CamFwrd = Camera.main.transform.forward; CamFwrd.y = 0f; CamFwrd.Normalize();
        Vector3 CamRght = Camera.main.transform.right; CamRght.y = 0f; CamRght.Normalize();
        Vector3 Movement = CamFwrd * MouseY + CamRght * MouseX;

        if (Input.GetKey(KeyCode.Mouse1) && TurnEnabled)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            OrbTrans.m_XAxis.m_InputAxisName = "Mouse X";
        }
        else if (Input.GetKey(KeyCode.Mouse2) && PanEnabled)
        {
            transform.Translate(Movement * CamSpeed * Time.deltaTime * -1, Space.World);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (OrbTrans != null)
        {
            OrbTrans.m_XAxis.m_InputAxisName = "";
            OrbTrans.m_XAxis.m_InputAxisValue = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
