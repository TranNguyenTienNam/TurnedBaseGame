using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    public HandCard creatureCardPrefab;
    public HandCard spellCardPrefab;
    public Transform handContent;

    public List<ScriptableCard> deck;

    public void AddCard()
    {
        if (deck.Count == 0)
        {
            Debug.Log("Deck is empty");
            return;
        }

        var card = deck[Random.Range(0, deck.Count - 1)];

        GameObject cardObj;
        HandCard slot;

        if (card is CreatureCard)
        {
            cardObj = Instantiate(creatureCardPrefab.gameObject);
            cardObj.transform.SetParent(handContent, false);
        }
        else
        {
            cardObj = Instantiate(spellCardPrefab.gameObject);
            cardObj.transform.SetParent(handContent, false);
        }

        slot = cardObj.GetComponent<HandCard>();
        slot.SetCardInfo(card, true);

        deck.Remove(card);
    }

    public void RemoveCard()
    {

    }
}
