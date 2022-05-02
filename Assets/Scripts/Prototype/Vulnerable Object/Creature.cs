using UnityEngine;
public class Creature : MonoBehaviour
{
    public bool isTargeting = false;
    public GameObject creatureUI;
    public GameObject targetingSignal;
    // TODO: Particle system for Damaged VFX

    [Header("Stats")]
    public int currentHealth;
    public int maxHealth;

    [HideInInspector] public CreatureCard cardInfo;
    [HideInInspector] public Combat combat;
    private Animator animator;

    private void Awake()
    {
        combat = GetComponent<Combat>();
        animator = GetComponentInChildren<Animator>();
    }

    public void OnInitialize(CreatureCard cardData, bool previewOnly = false)
    {
        cardInfo = cardData;

        animator.runtimeAnimatorController = cardData.animator;

        if (!previewOnly)
        {
            animator.Play("Idle"); // TODO: Not play?

            maxHealth = cardData.health;
            currentHealth = maxHealth;

            combat.healthBar.SetMaxHealth(maxHealth);
        }
    }

    public void OnAttack()
    {
        animator.SetTrigger("IsAttacking");
    }
    public void OnHit()
    {
        animator.SetTrigger("IsHit");
    }
}
