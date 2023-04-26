using UnityEngine.EventSystems;
using UnityEngine;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public RectTransform correctPosition;
    public float snapDistance = 10f;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;

        // Calculate the distance between the dropped position and the correct position
        float distance = Vector2.Distance(rectTransform.anchoredPosition, correctPosition.anchoredPosition);

        // If the distance is within the snap distance, snap the image to the correct position
        if (distance <= snapDistance)
        {
            rectTransform.anchoredPosition = correctPosition.anchoredPosition;
        }

        canvasGroup.blocksRaycasts = true;
    }
}
