using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSelector
{
    public static List<Creature> GetTargetList(Creature pivotTarget, Target target)
    {
        var results = new List<Creature>();
        switch (target)
        {
            case Target.PLAYER:
                break;
            case Target.ITSELF:
            default:
                results = GetItself(pivotTarget);
                break;
            case Target.ALLIES:
                results = GetAllies(pivotTarget);
                break;
            case Target.RANDOM:
                break;
            case Target.ALL:
                results = GetAllCreatureInBothFields();
                break;
        }
        return results;
    }

    private static List<Creature> GetItself(Creature pivotTarget)
    {
        var results = new List<Creature>();
        results.Add(pivotTarget);
        return results;
    }

    private static List<Creature> GetAllies(Creature pivotTarget)
    {
        var results = new List<Creature>();
        GameObject contentField;
        // TODO: Check player or opponent owns this creature
        if (true) contentField = GameObject.Find("PlayerField");
        else contentField = GameObject.Find("OpponentField");
        results = contentField.GetComponent<PlayerField>().spawnedCreatures.ToList();
        return results;
    }

    private static List<Creature> GetAllCreatureInBothFields()
    {
        var results = new List<Creature>();
        GameObject playerField = GameObject.Find("PlayerField");
        GameObject opponentField = GameObject.Find("OpponentField");

        results.AddRange(playerField.GetComponent<PlayerField>().spawnedCreatures.ToList());
        results.AddRange(opponentField.GetComponent<PlayerField>().spawnedCreatures.ToList());
        return results;
    }
}
