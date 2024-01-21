using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera worldCamera;
    public Camera playerCamera1;
    public Canvas uiCanvas1;
    public CarController carController; // Reference to the CarController script

    void Start()
    {
        // Initialize the cameras and UIs
        InitializeCameras();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        ToggleCarController(false);
    }

    void Update()
    {
        // Switch to the World Camera with the Tab key
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCamera(worldCamera);
            ShowUI(null);
            ToggleCarController(false); // Disable CarController
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            worldCamera.transform.parent?.gameObject.SetActive(true);
        }

        // Switch to Player Camera 1 with the 1 key
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchCamera(playerCamera1);
            ShowUI(uiCanvas1);
            ToggleCarController(true); // Enable CarController
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            worldCamera.transform.parent?.gameObject.SetActive(false);
        }
    }

    void SwitchCamera(Camera newCamera)
    {
        // Disable all cameras
        worldCamera.enabled = false;
        playerCamera1.enabled = false;

        // Enable the selected camera
        newCamera.enabled = true;
    }

    void ShowUI(Canvas uiCanvas)
    {
        // Disable all UI canvases
        if (uiCanvas1 != null) uiCanvas1.enabled = false;

        // Enable the UI canvas corresponding to the active camera
        if (uiCanvas != null) uiCanvas.enabled = true;
    }

    void InitializeCameras()
    {
        // Ensure all cameras start in the desired state
        SwitchCamera(worldCamera);
        ShowUI(null);
    }

    void ToggleCarController(bool enable)
    {
        // Enable or disable the CarController script based on the provided boolean value
        if (carController != null)
        {
            carController.enabled = enable;
        }

        // Disable the Rigidbody component to ensure the car stops moving
        if (carController != null && carController.GetComponent<Rigidbody>() != null)
        {
            carController.GetComponent<Rigidbody>().isKinematic = !enable;
        }
    }
}

