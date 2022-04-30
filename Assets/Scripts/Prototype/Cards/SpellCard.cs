using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Spell Card", order = 111)]
public class SpellCard : ScriptableCard
{
    [Header("Properties")]
    public List<CreatureCard> owners; // If the list is empty, every creature can cast this spell
    
    public List<CreatureCard> targetFamilies = new List<CreatureCard>();

    public int effectiveTurns = 1; // Whether the spell last until the end of the turn, within some turns or are permanent
    public override void Cast(Creature pivotTarget)
    {
        base.Cast(pivotTarget);
    }
}
