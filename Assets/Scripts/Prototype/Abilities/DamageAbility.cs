using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Damage & Heal", order = 111)]
public class DamageAbility : ScriptableAbility
{
    public override void Cast(List<Creature> targets, int amount)
    {
        foreach (var target in targets)
        {
            target.combat.CmdChangeHealth(amount);
            if (amount < 0) target.OnHit();
        }
    }
}
