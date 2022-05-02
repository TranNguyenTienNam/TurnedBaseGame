using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerField : MonoBehaviour, IDropHandler
{
    public Creature creaturePrefab;
    public Transform fieldContent;
    public GameObject previewDrag;

    [HideInInspector] public static bool nextCreatureIsOnFirstRow = true;
    [HideInInspector] public List<Creature> spawnedCreatures = new List<Creature>();
    public void OnDrop(PointerEventData eventData)
    {
        // TODO: Return if not our turn or not enough mana

        HandCard card = eventData.pointerDrag.transform.GetComponent<HandCard>();
        card.OnDrop(eventData, this);
        card.IsRemoved();

        //Player.localPlayer.CmdChangeMana(-card.cardInfo.cost);
    }

    public void RearrangeLastCreature()
    {
        if (!nextCreatureIsOnFirstRow)
        {
            Vector2 newPos = spawnedCreatures[spawnedCreatures.Count - 1].transform.localPosition;
            spawnedCreatures[spawnedCreatures.Count - 1].transform.localPosition = new Vector2(newPos.x, 150);
        }
        
        nextCreatureIsOnFirstRow = !nextCreatureIsOnFirstRow;
    }

    public void RearrangeCreaturePosition(GameObject creature)
    {
        if (!nextCreatureIsOnFirstRow)
        {
            Vector2 newPos = creature.transform.localPosition;
            creature.transform.localPosition = new Vector2(newPos.x, 150);
        }

        nextCreatureIsOnFirstRow = !nextCreatureIsOnFirstRow;
    }
}
