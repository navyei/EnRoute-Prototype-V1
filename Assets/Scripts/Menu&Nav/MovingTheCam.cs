using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTheCam : MonoBehaviour
{
    public float CamSpeed;
    public Camera Camera;
    public CinemachineVirtualCamera VirtualCamera;
    public CinemachineVirtualCameraBase[] VCams;

    private float MouseX;
	private float MouseY;
    private CinemachineOrbitalTransposer OrbTrans;

    void Start()
    {
        OrbTrans = VirtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        for (int i = 0;i < VCams.Length; i++)
        {
            VCams[i].Priority = i;
        }
    }

    void Update()
	{
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        Vector3 CamFwrd = Camera.main.transform.forward; CamFwrd.y = 0f; CamFwrd.Normalize();
        Vector3 CamRght = Camera.main.transform.right; CamRght.y = 0f; CamRght.Normalize();
        Vector3 Movement = CamFwrd*MouseY + CamRght*MouseX;

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            OrbTrans.m_XAxis.m_InputAxisName = "Mouse X";
        }
        else if (Input.GetKey(KeyCode.Mouse2))
        {
            transform.Translate(Movement * CamSpeed * Time.deltaTime, Space.World);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            OrbTrans.m_XAxis.m_InputAxisName = "";
            OrbTrans.m_XAxis.m_InputAxisValue = 0f;
        }
    }
}
