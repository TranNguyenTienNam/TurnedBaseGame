using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Mirror;

public abstract class HandCard : NetworkBehaviour
{
    [HideInInspector] public ScriptableCard cardInfo;

    [Header("Image")]
    public Image image;

    [Header("Front & Back")]
    public Image cardFront;
    public Image cardBack;

    [Header("Properties")]
    public Text cardName;
    public Text cost;
    public Text description;

    [Header("Event Handler")]
    public HandCardHover cardHover;
    public HandCardDrag cardDrag;

    [HideInInspector] public bool isTargeting = false;
    [HideInInspector] public bool isOwnedByPlayer;

    public bool CanExecute() => true; // IsOurTurn && isActive && selected entity is friendly
    public bool CannotExecute() => true;

    // Called from PlayerHand to instantiate the cards in the player's hand
    public virtual void SetCardInfo(ScriptableCard cardData, bool _isOwnedByPlayer = true)
    {
        cardInfo = cardData;

        isOwnedByPlayer = _isOwnedByPlayer;

        image.sprite = cardData.image;
        image.rectTransform.sizeDelta = cardData.image.rect.size;
        image.rectTransform.localScale = new Vector2(2.8f, 2.8f);

        // Reveal card FRONT, hide card BACK
        cardFront.color = Color.white;
        cardBack.color = Color.clear;

        // Assign to all properties
        cardName.text = cardData.name;
        description.text = cardData.description;
        cost.text = cardData.cost.ToString();
    }

    public abstract void OnBeginDrag(PointerEventData eventData);
    public abstract void OnDrag(PointerEventData eventData);
    public abstract void OnEndDrag(PointerEventData eventData);
    public abstract void OnPointerClick(PointerEventData eventData);
    public abstract void OnDrop(PointerEventData eventData, PlayerField playerField);

    // Called when we PLAY/REMOVE a card
    public void IsRemoved()
    {
        Destroy(gameObject);
    }
}
