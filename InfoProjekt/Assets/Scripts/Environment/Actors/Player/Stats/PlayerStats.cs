using System;
using System.Collections.Generic;
using Environment.Actors.Enemies;
using UnityEngine;

namespace Environment.Actors.Player.Stats
{
    public class PlayerStats: Actors.Stats
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
        
        private void Start()
        {
            status = new Status();
            Health = maxHealth;
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            level = status.Level;
            levelXP = status.LevelXP;
            maxHealth = status.Endurance * 0.69f;
            attackDamage = status.Strength * 0.69f;
            speed = status.Agility * 0.69f;
        }

        public override float DealDamage(float damageAmount)
        {
            Health -= damageAmount; 
            float receivedDamage;
            
            if (Health <= 0)
            {
                receivedDamage = damageAmount + Health;
                XPManager.AddReceivedDamage(receivedDamage);
                Health = 0;
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
    }
}