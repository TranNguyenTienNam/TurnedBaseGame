using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Deck : NetworkBehaviour
{
    [Header("Player")]
    public Player player;
    [HideInInspector] public int deckSize = 30;
    [HideInInspector] public int handSize = 7;

    [Header("Deck")]
    public SyncList<ScriptableCard> deckList = new SyncList<ScriptableCard>();
    public SyncList<ScriptableCard> graveyard = new SyncList<ScriptableCard>();
    public SyncList<ScriptableCard> hand = new SyncList<ScriptableCard>();

    [Header("Battlefield")]
    public List<Creature> playerField = new List<Creature>();

    [Header("Starting Deck")]
    public CardAndAmount[] startingDeck;

    public void DrawCard(int amount)
    {
        PlayerHand playerHand = Player.gameManager.playerHand;
        for (int i = 0; i < amount; i++)
        {
            playerHand.AddCard();
        }
    }

    [Command]
    public void CmdPlayCard(ScriptableCard cardInfo)
    {
        Debug.Log(cardInfo.name);

        var creatureObj = Instantiate(Player.gameManager.playerField.creaturePrefab.gameObject);
        creatureObj.GetComponent<Creature>().OnInitialize(cardInfo as CreatureCard);

        NetworkServer.Spawn(creatureObj);

        Debug.Log("Cmd");

        if (isServer) RpcPlayCard(creatureObj);
    }

    [ClientRpc]
    public void RpcPlayCard(GameObject creatureObj)
    {
        if (Player.gameManager.isSpawning)
        {
            Debug.Log("Rpc");
            creatureObj.transform.SetParent(Player.gameManager.playerField.fieldContent, false);
            Player.gameManager.playerField.spawnedCreatures.Add(creatureObj.GetComponent<Creature>());
            Player.gameManager.isSpawning = false;
        }
        else
        {
            creatureObj.transform.SetParent(Player.gameManager.opponentField.fieldContent, false);
            Player.gameManager.opponentField.spawnedCreatures.Add(creatureObj.GetComponent<Creature>());

            creatureObj.GetComponent<Creature>().creatureUI.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}