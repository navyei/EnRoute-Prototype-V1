using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DraggableCar : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Optional: Add logic for when drag starts
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 newPosition = rectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;
        // Restrict vertical movement
        newPosition.y = rectTransform.anchoredPosition.y;
        rectTransform.anchoredPosition = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (rectTransform.anchoredPosition.x > 490 || rectTransform.anchoredPosition.x < -490)
    {
        gameObject.SetActive(false);
    }// Optional: Add logic for when drag ends
    }
}
