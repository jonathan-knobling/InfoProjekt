using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Animator animator;

    [Header("Stats")]
    [SerializeField] public int level = 1;
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private float attackDamage = 30;
    private float levelMultiplier = 2.5f;
    private float hiddenMaxHealth => (levelMultiplier * level * maxHealth);
    private float hiddenAttackDamage => (int)(levelMultiplier * level * attackDamage);
    private float health;

    private void Start()
    {
        health = hiddenMaxHealth;
    }

    void Update()
    {

    }

    public void Hit(float damage)
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
        animator.SetTrigger("death");
        Destroy(gameObject);
    }

    public int GetLevel()
    {
        return level;
    }
}
