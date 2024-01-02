using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera worldCamera;
    public Camera playerCamera1;
    public Camera playerCamera2;
    public Camera playerCamera3;

    public Canvas uiCanvas1;
    public Canvas uiCanvas2;
    public Canvas uiCanvas3;

    void Start()
    {
        // Initialize the cameras and UIs
        InitializeCameras();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        // Switch to the World Camera with the Tab key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCamera(worldCamera);
            ShowUI(null);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        // Switch to Player Camera 1 with the 1 key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera(playerCamera1);
            ShowUI(uiCanvas1);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Switch to Player Camera 2 with the 2 key
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchCamera(playerCamera2);
            ShowUI(uiCanvas2);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Switch to Player Camera 3 with the 3 key
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchCamera(playerCamera3);
            ShowUI(uiCanvas3);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void SwitchCamera(Camera newCamera)
    {
        // Disable all cameras
        worldCamera.enabled = false;
        playerCamera1.enabled = false;
        playerCamera2.enabled = false;
        playerCamera3.enabled = false;

        // Enable the selected camera
        newCamera.enabled = true;
    }

    void ShowUI(Canvas uiCanvas)
    {
        // Disable all UI canvases
        if (uiCanvas1 != null) uiCanvas1.enabled = false;
        if (uiCanvas2 != null) uiCanvas2.enabled = false;
        if (uiCanvas3 != null) uiCanvas3.enabled = false;

        // Enable the UI canvas corresponding to the active camera
        if (uiCanvas != null) uiCanvas.enabled = true;
    }

    void InitializeCameras()
    {
        // Ensure all cameras start in the desired state
        SwitchCamera(worldCamera);
        ShowUI(null);
    }
}






