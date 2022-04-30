using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CardAndAmount
{
    public ScriptableCard card;
    public int amount;
}
public class ScriptableCard : ScriptableObject
{
    [SerializeField] string id = "";
    public string cardID { get { return id; } }

    [Header("Image")]
    public Sprite image;

    [Header("Properties")]
    public int cost;
    public string category;

    [Header("Description")]
    [SerializeField, TextArea(1, 30)] public string description;

    [Header("Initiative Abilities")]
    public List<CardAbility> initiatives = new List<CardAbility>();

    // By default, all abilities can be casted without any conditions
    public virtual void Cast(Creature pivotTarget)
    {
        foreach (var cardAbility in initiatives)
        {
            cardAbility.Cast(pivotTarget);
        }
    }
}

public enum Target : byte { PLAYER, ITSELF, ALLIES, RANDOM, ALL }
