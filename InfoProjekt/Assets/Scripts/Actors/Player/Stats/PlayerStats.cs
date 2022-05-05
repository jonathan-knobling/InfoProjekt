using System.Collections.Generic;
using Actors.Enemies;
using Environment;
using Tech.IO.Saves;
using UnityEngine;

namespace Actors.Player.Stats
{
    public class PlayerStats: MonoBehaviour, ISaveable, IDamagable
    {
        private static readonly int CPDeath = Animator.StringToHash("death");

        private Animator animator;
        private Status status;
        
        public StatsXPManager XPManager => status.XPManager;

        public bool LevelUpPossible => status.LevelUpPossible;
        public bool StatusUpdatePossible => status.StatusUpdatePossible;
        public Dictionary<StatusAbility, int> CurrentStatus => status.CurrentStatus;
        public Dictionary<StatusAbility, int> HiddenStatus => status.HiddenStatus;
        public Dictionary<StatusAbility, float> TotalStatus => status.TotalStatus;
        public Dictionary<StatusAbility, float> CurrentXP => status.CurrentXP;
        
        private float health;
        private float mp;
        
        public int Level => status.Level;
        public float LevelXP => status.LevelXP;
        public float MaxHealth => status.Endurance * 0.69f;
        public float MaxMP => status.Magic * 0.69f;
        public float AttackDamage => status.Strength * 0.69f;
        public float Speed => status.Agility * 0.69f;
        public float Health => health;
        public float MP => mp;
        public float HealthPercentage => health / MaxHealth;
        public float MPPercentage => mp / MaxMP;

        private void Awake()
        {
            status = new Status();
            health = MaxHealth;
            animator = GetComponent<Animator>();
        }

        public float DealDamage(float damageAmount)
        {
            health -= damageAmount; 
            float receivedDamage;
            
            if (health <= 0)
            {
                receivedDamage = damageAmount + health;
                XPManager.AddReceivedDamage(receivedDamage);
                health = 0;
                Die();
                return receivedDamage;
            }

            receivedDamage = damageAmount;
            XPManager.AddReceivedDamage(receivedDamage);
            return receivedDamage;
        }

        private void Die()
        {
            animator.SetTrigger(CPDeath);
        }

        public void AddXP(EnemyStats enemy)
        {
            status.AddXP(enemy);
        }

        public void LevelUp()
        {
            status.LevelUp();
        }

        public void StatusUpdate()
        {
            status.StatusUpdate();
        }


        //saving
        public object SerializeComponent()
        {
            return status.SerializeComponent();
        }

        public void ApplySerializedData(object serializedData)
        {
            status.ApplySerializedData(serializedData);
        }
        
        
        //testing
        private void Update()
        {
            if (Input.GetKey(KeyCode.K))
            {
                health -= 0.01f;
            }

            if (Input.GetKey(KeyCode.L))
            {
                health += 0.01f;
            }

            if (health < 0) health = 0;
            if (health > MaxHealth) health = MaxHealth;
            
            Debug.Log(health);
        }/**/
    }
}