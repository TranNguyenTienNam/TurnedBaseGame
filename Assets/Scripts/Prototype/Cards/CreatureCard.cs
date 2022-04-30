using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/Creature Card", order = 111)]
public class CreatureCard : ScriptableCard
{
    [Header("Stats")]
    public int health;
    public int strength;

    [Header("Targets")]
    public List<Target> acceptableTargets = new List<Target>();

    [Header("Death Abilities")]
    public List<CardAbility> deathAbilities = new List<CardAbility>();

    [Header("Animator")]
    public AnimatorOverrideController animator;

    public override void Cast(Creature pivotTarget)
    {
        base.Cast(pivotTarget);
    }
    public virtual void OnCreatureDead(Creature pivotTarget)
    {
        foreach (var cardAbility in deathAbilities)
        {
            cardAbility.Cast(pivotTarget);
        }
    }
}
