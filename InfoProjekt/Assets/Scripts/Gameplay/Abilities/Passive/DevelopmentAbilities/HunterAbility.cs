using System.Collections.Generic;
using System.Linq;
using Actors.Enemies;
using Actors.Player.Stats;
using Tech;
using Tech.IO.Saves;
using UnityEngine;

namespace Gameplay.Abilities.Passive.DevelopmentAbilities
{
    [CreateAssetMenu(menuName = "Abilities/Passive/Development Ability/Hunter", fileName = "Hunter")]
    public class HunterAbility: DevelopmentAbility
    {
        [SerializeField] private float damageModifier;
        [SerializeField] private float xpModifier;
        
        private List<string> killedEnemies;

        public float DamageModifier => damageModifier;
        public float XPModifier => xpModifier;

        public override void Init(GameObject parentObject, PlayerStats playerStats, EventChannelSO eventChannel)
        {
            id = "hunter";
            killedEnemies = new List<string>();
            rank = StatusRank.I;
            eventChannel.PlayerChannel.OnEnemyKilled += AddKilledEnemy;
         
            var modifier = new HunterAbilityDamageModifier(this);
            playerStats.DamageModifiers.Add(modifier);
        }

        public override void Update()
        {
            
        }

        public bool HasKilled(string enemyID)
        {
            return killedEnemies.Contains(enemyID);
        }

        private void AddKilledEnemy(string enemyID)
        {
            if (killedEnemies.Contains(enemyID)) return;
            killedEnemies.Add(enemyID);
        }

        
        //Serialization
        public override object SerializeComponent()
        {
            return new SaveData()
            {
                KilledEnemies = killedEnemies.ToArray(),
                Rank = rank
            };
        }

        public override void ApplySerializedData(object serializedData)
        {
            rank = ((SaveData) serializedData).Rank;
            killedEnemies = ((SaveData) serializedData).KilledEnemies.ToList();
        }

        private struct SaveData
        {
            public string[] KilledEnemies;
            public StatusRank Rank;
        }
    }
    
    public class HunterAbilityDamageModifier: IDamageModifier
    {
        private readonly HunterAbility parent;

        public HunterAbilityDamageModifier(HunterAbility parent)
        {
            this.parent = parent;
        }
        
        public float CalculateDamage(EnemyStats enemyStats, float baseDamage)
        {
            if (!parent.HasKilled(enemyStats.enemyID)) return baseDamage;

            return baseDamage * parent.DamageModifier;
        }
    }
}