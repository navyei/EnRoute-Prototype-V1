using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager Instance { get; private set; }

    public GameObject carObjectsContainer;

    private List<GameObject> carObjects = new List<GameObject>();

    void Awake()
    {
        Instance = this;

        // Populate the list of car objects
        foreach (Transform child in carObjectsContainer.transform)
        {
            carObjects.Add(child.gameObject);
        }
    }

    public void ActivateCarObjects()
    {
        foreach (var obj in carObjects)
        {
            obj.SetActive(true);
        }
    }

    public void DeactivateCarObjects()
    {
        foreach (var obj in carObjects)
        {
            obj.SetActive(false);
        }
    }

    // This function is called by InteractiveObject to check if the object is interacted with
    public void CheckObjectInteraction(InteractiveObject interactiveObject)
    {
        if (carObjects.Contains(interactiveObject.gameObject))
        {
            // The interactive object is inside the car, handle interaction as needed
            HandleCarObjectInteraction(interactiveObject);
        }
        else
        {
            // The interactive object is outside the car, handle interaction as needed
            HandleNonCarObjectInteraction(interactiveObject);
        }
    }

    private void HandleCarObjectInteraction(InteractiveObject interactiveObject)
    {
        // Add specific logic for interacting with objects inside the car
        // For example, you can call a method on the InteractiveObject to handle the interaction
        interactiveObject.Interact();
    }

    private void HandleNonCarObjectInteraction(InteractiveObject interactiveObject)
    {
        // Add specific logic for interacting with objects outside the car
        // For example, you can call a method on the InteractiveObject to handle the interaction
        interactiveObject.Interact();
    }
}



