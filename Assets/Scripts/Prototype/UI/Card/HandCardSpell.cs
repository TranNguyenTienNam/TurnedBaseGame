using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class HandCardSpell : HandCard
{
    public Target casterType;

    private Creature mainTarget;
    private List<Creature> targets = new List<Creature>();

    public override void OnBeginDrag(PointerEventData eventData)
    {
        
    }

    public override void OnDrag(PointerEventData eventData)
    {
        RaycastHit2D[] hitInfo = Physics2D.CircleCastAll(transform.position, 0.1f, Vector2.zero, 1f, LayerMask.GetMask("Creature"));

        if (hitInfo.Length > 0)
        {
            var newTarget = hitInfo[0].collider.gameObject.GetComponent<Creature>();
            // Player has just selected a creature or changed the main target
            if (newTarget != mainTarget)
            {
                mainTarget = newTarget;

                foreach (var target in targets)
                {
                    target.targetingSignal.SetActive(false);
                }
                targets.Clear();

                foreach (var ability in cardInfo.initiatives)
                {
                    var _targets = TargetSelector.GetTargetList(mainTarget, ability.targetType);
                    targets.AddRange(_targets);
                }
            }
        }
        else
        {
            // Player no longer selects the main target
            if (mainTarget)
            {
                mainTarget = null;
                foreach (var target in targets)
                {
                    target.targetingSignal.SetActive(false);
                }
                targets.Clear();
            }
        }

        foreach (var target in targets)
        {
            target.targetingSignal.SetActive(true);
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
