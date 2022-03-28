using System;
using System.Collections.Generic;
using Environment.Actors.Enemies;
using Tech.IO.Saves;
using UnityEngine;

namespace Environment.Actors.Player.Stats
{
    public class PlayerStats: Actors.Stats, ISaveable
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
        
        private void Awake()
        {
            status = new Status();
            Health = MaxHealth;
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Level = status.Level;
            LevelXP = status.LevelXP;
            MaxHealth = status.Endurance * 0.69f;
            AttackDamage = status.Strength * 0.69f;
            Speed = status.Agility * 0.69f;
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

        
        //saving
        public object SerializeComponent()
        {
            return status.SerializeComponent();
        }

        public void ApplySerializedData(object data)
        {
            status.ApplySerializedData(data);
        }
    }
}