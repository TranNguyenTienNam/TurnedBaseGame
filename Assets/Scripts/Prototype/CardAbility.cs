using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CardAbility
{
    public Target targetType;
    public ScriptableAbility ability;
    public int amount;

    public void Cast(Creature pivotTarget)
    {
        var targetList = new List<Creature>();
        targetList = TargetSelector.GetTargetList(pivotTarget, targetType);
        ability.Cast(targetList, amount);
    }
}
