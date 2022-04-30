using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [Header("Player Info")]
    public string username;

    [Header("Portrait")]
    public Sprite portrait;

    [Header("Deck")]
    public Deck deck;
    public Sprite cardBack;

    [Header("Stats")]
    public int health;
    public int maxHealth;

    public int maxMana = 10;
    public int currentMaxMana = 0;
    public int currentMana = 0;

    [HideInInspector] public static Player localPlayer;
    [HideInInspector] public static GameManager gameManager;
    [HideInInspector] public Combat combat;

    private void Awake()
    {
        combat = GetComponent<Combat>();
    }

    public override void OnStartLocalPlayer()
    {
        localPlayer = this;

        CmdLoadPlayer(PlayerPrefs.GetString("Name"));
    }

    public override void OnStartClient()
    {
        base.OnStartClient();


    }

    [Command]
    public void CmdLoadPlayer(string user)
    {
        username = user;
    }

    [Command]
    public void CmdLoadDeck()
    {
        for (int i = 0; i < deck.startingDeck.Length; i++)
        {
            CardAndAmount card = deck.startingDeck[i];
            for (int j = 0; j < card.amount; j++)
            {
                deck.deckList.Add(card.card);
            }
        }
    }

    [Command]
    public void CmdChangeMana(int amount)
    {
        currentMana += amount;
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        maxHealth = gameManager.maxHealth;
        maxMana = gameManager.maxMana;
        deck.deckSize = gameManager.deckSize;
        deck.handSize = gameManager.handSize;
    }
}
