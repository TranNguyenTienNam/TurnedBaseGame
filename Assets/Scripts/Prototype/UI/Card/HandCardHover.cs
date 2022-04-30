using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCardHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Vector2 hoverScale = new Vector2(1.0f, 1.0f);
    [SerializeField] private Vector2 defaultScale;

    [HideInInspector] public HandCard card;
    private bool isSelected = false;
    public void Awake()
    {
        card = GetComponent<HandCard>();
        defaultScale = card.transform.localScale;
    }
    public void Update()
    {
        if (isSelected && Input.GetMouseButtonDown(1))
        {
            isSelected = false;
            Unhover();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = true;

        card.OnPointerClick(eventData);

        Hover();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isSelected) return;

        // Move card locally
        Hover();
        int index = card.transform.GetSiblingIndex();

        // TODO: Move corresponding card on opponent's screen
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isSelected) return;

        // Return to normal
        Unhover();

        // TODO: Move corresponding card back to normal on opponent's screen
    }

    public void Hover()
    {
        card.transform.localScale = hoverScale;
        card.transform.localPosition = new Vector2(card.transform.localPosition.x, 140);
    }

    public void Unhover()
    {
        card.transform.localScale = defaultScale;
        card.transform.localPosition = new Vector2(card.transform.localPosition.x, 0);
    }
}
