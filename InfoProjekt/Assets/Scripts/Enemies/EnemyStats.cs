using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enemies
{
    public class EnemyStats : MonoBehaviour
    {
        [SerializeField] public Animator animator;
        
        [Header("Stats")] 
        [SerializeField] public string enemyID;
        [SerializeField] public int level = 1;
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float attackDamage = 3;
        [SerializeField] private int xpAmount = 2;
        private const float LevelMultiplier = 2.5f;
        private float hiddenMaxHealth => (LevelMultiplier * level * maxHealth);
        private float hiddenAttackDamage => (int)(LevelMultiplier * level * attackDamage);
        private float health;
    

        private void Start()
        {
            health = hiddenMaxHealth;
        }

        public void Hit(float damage)
        {
            animator.SetTrigger("hit");
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
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

        public bool IsDead()
        {
            return health < 0;
        }

        public int GetXpAmount()
        {
            return xpAmount;
        }

        public float GetAttackDamage()
        {
            return hiddenAttackDamage;
        }

        public float GetSpeed()
        {
            return (float) ((1 + 0.25 * level) * 5);
        }

        public float GetRoamingSpeed()
        {
            return (float) ((1 + 0.15 * level) * 5);
        }
    }
}
