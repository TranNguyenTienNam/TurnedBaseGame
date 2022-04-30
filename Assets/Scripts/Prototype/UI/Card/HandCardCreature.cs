using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HandCardCreature : HandCard
{
    [Header("Properties")]
    public Text strength;
    public Text health;

    private PlayerField playerField;
    private GraphicRaycaster graphicRaycaster;

    public override void SetCardInfo(ScriptableCard cardData, bool ownerIsPlayer = true)
    {
        base.SetCardInfo(cardData, ownerIsPlayer);

        health.text = (cardData as CreatureCard).health.ToString();
        strength.text = (cardData as CreatureCard).strength.ToString();
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {

    }

    public override void OnDrag(PointerEventData eventData)
    {
        if (playerField == null)
        {
            var results = new List<RaycastResult>();

            if (graphicRaycaster == null)
            {
                graphicRaycaster = GetComponentInParent<Canvas>().GetComponent<GraphicRaycaster>();
            }
            graphicRaycaster.Raycast(eventData, results);

            foreach (var hit in results)
            {
                var _playerField = hit.gameObject.GetComponent<PlayerField>();

                if (_playerField)
                {
                    playerField = _playerField;
                    break;
                }
            }
        }

        if (playerField)
        {
            if (playerField.previewDrag.activeInHierarchy == true) return;

            playerField.previewDrag.SetActive(true);
            playerField.previewDrag.GetComponent<Creature>().OnInitialize(cardInfo as CreatureCard, true);
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        if (playerField)
        {
            playerField.previewDrag.SetActive(false);
        }
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        
    }

    public override void OnDrop(PointerEventData eventData, PlayerField playerField)
    {
        Player.gameManager.isSpawning = true;

        Player.localPlayer.deck.CmdPlayCard(cardInfo);
        
        // TODO: BUG: Position y not change
        //playerField.RearrangeCreaturePosition(creature);

        playerField.previewDrag.SetActive(false);
    }
}
