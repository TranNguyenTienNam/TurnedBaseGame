using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetSelector
{
    public List<Creature> GetTargetList(Creature pivotTarget, Target target)
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
                results = GetAllCreatureInBothField();
                break;
        }
        return results;
    }

    private List<Creature> GetItself(Creature pivotTarget)
    {
        var results = new List<Creature>();
        results.Add(pivotTarget);
        return results;
    }

    private List<Creature> GetAllies(Creature pivotTarget)
    {
        var results = new List<Creature>();
        GameObject contentField;
        // TODO: Check player or opponent owns this creature
        if (true) contentField = GameObject.Find("PlayerField");
        else contentField = GameObject.Find("OpponentField");
        results = contentField.GetComponent<PlayerField>().spawnedCreatures.ToList();
        return results;
    }

    private List<Creature> GetAllCreatureInBothField()
    {
        var results = new List<Creature>();
        GameObject playerField = GameObject.Find("PlayerField");
        GameObject opponentField = GameObject.Find("OpponentField");

        results.AddRange(playerField.GetComponent<PlayerField>().spawnedCreatures.ToList());
        results.AddRange(opponentField.GetComponent<PlayerField>().spawnedCreatures.ToList());
        return results;
    }
}
