using System.ComponentModel;
using UnityEngine;

namespace Environment.Actors.Enemies
{
    public class EnemyStats : Stats
    {
        [Header("Animator")]
        private static readonly int AnimatorHit = Animator.StringToHash("hit");
        private static readonly int Death = Animator.StringToHash("death");
        [SerializeField] public Animator animator;
        
        [Header("Stats")] 
        [SerializeField] public string enemyID;
        [SerializeField] public int level = 1;
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float defenseMultiplier = 1;
        [SerializeField] private float attackDamage = 3;
        [SerializeField] private int xpAmount = 2;
        private const float LevelMultiplier = 2.5f;
        private float HiddenMaxHealth => (LevelMultiplier * level * maxHealth);
        private float HiddenAttackDamage => (int)(LevelMultiplier * level * attackDamage);
        private new float Health;

        //getters
        public new int Level => level;
        public bool IsDead => Health <= 0;
        public int XPAmount => xpAmount;
        public new float AttackDamage => HiddenAttackDamage;
        public new float Speed => (float) ((1 + 0.25 * level) * 5);
        public float RoamingSpeed => (float) ((1 + 0.15 * level) * 5);

        private void Start()
        {
            Health = HiddenMaxHealth;
        }

        [Description("Returns the actually dealt damage")]
        public override float DealDamage(float damage)
        {
            float actualDamage = damage * defenseMultiplier;
            Health -= damage;
            
            
            if (Health <= 0)
            {
                Die();
                
                //relevant wenn health < 0
                actualDamage -= Health;
                return actualDamage;
            }

            animator.SetTrigger(AnimatorHit);
            return actualDamage;
        }

        private void Die()
        {
            animator.SetTrigger(Death);
            Destroy(gameObject);
        }
    }
}
