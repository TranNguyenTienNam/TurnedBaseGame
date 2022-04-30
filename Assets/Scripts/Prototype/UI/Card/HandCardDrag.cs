using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandCardDrag : MonoBehaviour, 
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public HandCard card;
    public CanvasGroup canvasGroup;
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;

        card.OnBeginDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 screenPoint = eventData.position;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

        card.OnDrag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;

        card.OnEndDrag(eventData);
    }
}
