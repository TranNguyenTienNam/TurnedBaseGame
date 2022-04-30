using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class GameManager : NetworkBehaviour
{
    [Header("Health & Mana")]
    public int maxHealth = 30;
    public int maxMana = 10;

    [Header("Hand")]
    public int handSize = 7;
    public PlayerHand playerHand;

    [Header("Deck")]
    public int deckSize = 30;

    [Header("Battlefield")]
    public PlayerField playerField;
    public PlayerField opponentField;

    [Header("Turn Management")]
    public Button endTurnButton;
    
    [HideInInspector] public bool isOurTurn = false;
    [HideInInspector] public bool isSpawning = false;

    [Command]
    public void CmdEndTurn()
    {
        RpcSetTurn();
    }

    [ClientRpc]
    public void RpcSetTurn()
    {
        isOurTurn = !isOurTurn;
        endTurnButton.interactable = isOurTurn;

        if (isOurTurn)
        {

        }
    }
}
