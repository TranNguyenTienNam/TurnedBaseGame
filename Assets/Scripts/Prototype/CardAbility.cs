using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CardAbility
{
    public List<Target> targetTypes;
    public ScriptableAbility ability;
    public int amount;

    public void Cast(Creature pivotTarget)
    {
        var targetList = new List<Creature>();
        var targetSelector = new TargetSelector();
        foreach (var targetType in targetTypes)
        {
            targetList.AddRange(targetSelector.GetTargetList(pivotTarget, targetType));
        }
        ability.Cast(targetList, amount);
    }
}
