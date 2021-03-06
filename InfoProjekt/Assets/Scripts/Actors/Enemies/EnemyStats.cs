using System;
using System.Collections;
using System.ComponentModel;
using System.Threading;
using Environment;
using Tech.IO.Saves;
using UnityEngine;

namespace Actors.Enemies
{
    public class EnemyStats : MonoBehaviour, IDamagable, ISaveable
    {
        [Header("Animator")]
        private static readonly int AnimatorTriggerHurt = Animator.StringToHash("hurt");
        private static readonly int AnimatorTriggerDie = Animator.StringToHash("die");
        [SerializeField] public Animator animator;
        
        [Header("Info")]
        [SerializeField] public string enemyID;
        [SerializeField] private EnemyType type;
        
        [Header("Stats")]
        [SerializeField] public int level = 1;
        [SerializeField] private float maxHealth = 10;
        [SerializeField] private float defenseMultiplier = 1;
        [SerializeField] private float attackDamage = 3;
        [SerializeField] private int xpAmount = 2;
        private const float LevelMultiplier = 2.5f;
        private float HiddenMaxHealth => (LevelMultiplier * level * maxHealth);
        private float HiddenAttackDamage => (int)(LevelMultiplier * level * attackDamage);
        private float health;

        //getters
        public int Level => level;
        public bool IsDead => health <= 0;
        public int XPAmount => xpAmount;
        public float AttackDamage => HiddenAttackDamage;
        public float Speed => (float) ((1 + 0.25 * level) * 1.5f);
        public float RoamingSpeed => (float) ((1 + 0.15 * level) * 1.4f);
        public EnemyType Type => type;

        private void Start()
        {
            health = HiddenMaxHealth;
        }

        [Description("Returns the actually dealt damage")]
        public float DealDamage(float damage)
        {
            float actualDamage = damage * defenseMultiplier;
            health -= damage;
            
            Debug.Log("damage dealt");
            
            if (health <= 0)
            {
                StartCoroutine(Die());
                
                //relevant wenn health < 0
                actualDamage -= health;
                return actualDamage;
            }

            animator.SetTrigger(AnimatorTriggerHurt);
            return actualDamage;
        }

        private IEnumerator Die()
        {
            animator.SetTrigger(AnimatorTriggerDie);
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }

        
        //Saving
        public object SerializeComponent()
        {
            return new SaveData()
            {
                healthData = health
            };
        }

        public void ApplySerializedData(object serializedData)
        {
            var data = (SaveData) serializedData;
            health = data.healthData;
        }

        [Serializable]
        private struct SaveData
        {
            public float healthData;
        }
    }
}
