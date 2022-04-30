using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HandCardSpell : HandCard
{
    public Target casterType;

    private Creature currentTarget;

    public override void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        RaycastHit2D[] hitInfo = Physics2D.CircleCastAll(transform.position, 0.1f, Vector2.zero, 1f, LayerMask.GetMask("Creature"));
        if (hitInfo.Length > 0)
        {
            var newTarget = hitInfo[0].collider.gameObject.GetComponent<Creature>();
            if (newTarget != currentTarget)
            {
                if (currentTarget) currentTarget.targetingSignal.SetActive(false);
                newTarget.targetingSignal.SetActive(true);
                currentTarget = newTarget;
            }
        }
        else
        {
            if (currentTarget)
            {
                currentTarget.targetingSignal.SetActive(false);
                currentTarget = null;
            }
        }
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {

    }

    public override void OnDrop(PointerEventData eventData, PlayerField playerField)
    {
        RaycastHit2D[] hitInfo = Physics2D.CircleCastAll(transform.position, 0.1f, Vector2.zero, 1f, LayerMask.GetMask("Creature"));
        if (hitInfo.Length > 0)
        {
            Creature target = hitInfo[0].collider.gameObject.GetComponent<Creature>();
            (cardInfo as SpellCard).Cast(target);

            target.targetingSignal.SetActive(false);
        }
    }
}
