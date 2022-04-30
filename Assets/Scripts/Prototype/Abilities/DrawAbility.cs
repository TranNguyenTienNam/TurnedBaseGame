using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability/Draw", order = 111)]
public class DrawAbility : ScriptableAbility
{
    public override void Cast(List<Creature> targets, int amount)
    {
        var playerHand = GameObject.Find("PlayerHand").GetComponent<PlayerHand>();
        for (int i = 0; i < amount; i++)
        {
            playerHand.AddCard();
        }
    }
}
