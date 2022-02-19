using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Animator animator;

    [Header("Stats")]
    [SerializeField] public int level = 1;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float attackDamage = 30;
    private float levelMultiplier = 2.5f;
    private int hiddenMaxHealth => (int)(levelMultiplier * level * maxHealth);
    private float hiddenAttackDamage => (int)(levelMultiplier * level * attackDamage);
    private int health;

    private void Start()
    {
        health = hiddenMaxHealth;
    }

    void Update()
    {

    }

    public void Hit(int damage)
    {
        animator.SetTrigger("hit");
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        Debug.Log(name + " " + health);
    }

    public void Die()
    {
        animator.SetTrigger("die");
        Destroy(gameObject);
    }

    public int GetLevel()
    {
        return level;
    }
}
