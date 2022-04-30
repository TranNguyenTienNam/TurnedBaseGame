using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [HideInInspector] public Creature creature;
    [HideInInspector] public HealthBar healthBar;
    private void Awake()
    {
        creature = GetComponent<Creature>();
        healthBar = GetComponentInChildren<HealthBar>();
    }
    public void CmdChangeHealth(int amount)
    {
        creature.currentHealth += amount;

        healthBar.SetHealth(creature.currentHealth);
    }
}
