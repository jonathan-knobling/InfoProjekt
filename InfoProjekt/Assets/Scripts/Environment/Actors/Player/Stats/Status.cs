using System.Collections.Generic;
using Environment.Actors.Enemies;
using UnityEngine;

namespace Environment.Actors.Player.Stats
{
    public class Status
    {
        public StatsXPManager XPManager { get; }

        private const float LevelMultiplier = 0.7f;                                      //over
        private readonly int[] xpThreshold = {0, 4, 8, 15, 16, 23, 42, 69, 420, 911, 1337, 9000, 69420};
        
        public int Level { get; private set; }
        
        public readonly Dictionary<StatusAbility, int> CurrentStatus;
        public readonly Dictionary<StatusAbility, int> HiddenStatus;
        public readonly Dictionary<StatusAbility, float> CurrentXP;

        public Status()
        {
            CurrentStatus = new Dictionary<StatusAbility, int>(5)
            {
                {StatusAbility.Strength, 10},
                {StatusAbility.Endurance, 10},
                {StatusAbility.Agility, 10},
                {StatusAbility.Dexterity, 10},
                {StatusAbility.Magic, 10}
            };
            HiddenStatus = new Dictionary<StatusAbility, int>(5)
            {
                {StatusAbility.Strength, 10},
                {StatusAbility.Endurance, 10},
                {StatusAbility.Agility, 10},
                {StatusAbility.Dexterity, 10},
                {StatusAbility.Magic, 10}
            };
            CurrentXP = new Dictionary<StatusAbility, float>(5)
            {
                {StatusAbility.Strength, 0},
                {StatusAbility.Endurance, 0},
                {StatusAbility.Agility, 0},
                {StatusAbility.Dexterity, 0},
                {StatusAbility.Magic, 0}
            };
            
            XPManager = new StatsXPManager(this);
            Level = 1;
            LevelXP = 0;
        }
        
        public float Strength => (CurrentStatus[StatusAbility.Strength] 
                                  + HiddenStatus[StatusAbility.Strength]) * Level * LevelMultiplier;
        public float Endurance => (CurrentStatus[StatusAbility.Endurance] 
                                   + HiddenStatus[StatusAbility.Endurance]) * Level * LevelMultiplier;
        public float Dexterity => (CurrentStatus[StatusAbility.Dexterity] 
                                   + HiddenStatus[StatusAbility.Dexterity]) * Level * LevelMultiplier;
        public float Agility => (CurrentStatus[StatusAbility.Agility] 
                                 + HiddenStatus[StatusAbility.Agility]) * Level * LevelMultiplier;
        public float Magic => (CurrentStatus[StatusAbility.Magic] 
                               + HiddenStatus[StatusAbility.Magic]) * Level * LevelMultiplier;
        
        public void AddStrengthXP(float xpAmount)
        {
            CurrentXP[StatusAbility.Strength] += xpAmount;
        }

        public void AddEnduranceXP(float xpAmount)
        {
            CurrentXP[StatusAbility.Endurance] += xpAmount;
        }

        public void AddDexterityXP(float xpAmount)
        {
            CurrentXP[StatusAbility.Dexterity] += xpAmount;
        }

        public void AddMagicXP(float xpAmount)
        {
            CurrentXP[StatusAbility.Magic] += xpAmount;
        }

        public void AddAgilityXP(float xpAmount)
        {
            CurrentXP[StatusAbility.Agility] += xpAmount;
        }
        
        public float LevelXP { get; private set; }

        public Dictionary<StatusAbility, float> TotalStatus => new Dictionary<StatusAbility, float>(5)
        {
            {StatusAbility.Strength, Strength},
            {StatusAbility.Endurance, Endurance},
            {StatusAbility.Agility, Agility},
            {StatusAbility.Dexterity, Dexterity},
            {StatusAbility.Magic, Magic}
        };

        public bool LevelUpPossible =>
            (CurrentStatus[StatusAbility.Strength] >= 600 || CurrentStatus[StatusAbility.Endurance] 
             >= 600 || CurrentStatus[StatusAbility.Dexterity] >= 600 || CurrentStatus[StatusAbility.Agility] >= 600 
             || CurrentStatus[StatusAbility.Magic] >= 600) && LevelXP > xpThreshold[Level];

        public bool StatusUpdatePossible => 
            CurrentXP[StatusAbility.Strength] > 0 || CurrentXP[StatusAbility.Endurance] > 0 
         || CurrentXP[StatusAbility.Dexterity] > 0 || CurrentXP[StatusAbility.Agility] > 0 
         || CurrentXP[StatusAbility.Magic] > 0;

        public void LevelUp()
        {
            if (!LevelUpPossible) return;
            StatusUpdate();

            LevelXP -= xpThreshold[Level];
            Level++;
            
            foreach (var (key, value) in CurrentStatus)
            {
                HiddenStatus[key] += value;
            }
            
            HiddenStatus[StatusAbility.Strength] += CurrentStatus[StatusAbility.Strength];
            CurrentStatus[StatusAbility.Strength] = 10;
            
            HiddenStatus[StatusAbility.Endurance] += CurrentStatus[StatusAbility.Endurance];
            CurrentStatus[StatusAbility.Endurance] = 10;
            
            HiddenStatus[StatusAbility.Dexterity] += CurrentStatus[StatusAbility.Dexterity];
            CurrentStatus[StatusAbility.Dexterity] = 10;
            
            HiddenStatus[StatusAbility.Agility] += CurrentStatus[StatusAbility.Agility];
            CurrentStatus[StatusAbility.Agility] = 10;
            
            HiddenStatus[StatusAbility.Magic] += CurrentStatus[StatusAbility.Magic];
            CurrentStatus[StatusAbility.Magic] = 10;
        }

        public void StatusUpdate()
        {
            if (!StatusUpdatePossible) return;

            CurrentStatus[StatusAbility.Strength] += (int) CurrentXP[StatusAbility.Strength];
            CurrentXP[StatusAbility.Strength] -= (int) CurrentXP[StatusAbility.Strength];

            CurrentStatus[StatusAbility.Endurance] += (int) CurrentXP[StatusAbility.Endurance];
            CurrentXP[StatusAbility.Endurance] -= (int) CurrentXP[StatusAbility.Endurance];

            CurrentStatus[StatusAbility.Dexterity] += (int) CurrentXP[StatusAbility.Dexterity];
            CurrentXP[StatusAbility.Dexterity] -= (int) CurrentXP[StatusAbility.Dexterity];

            CurrentStatus[StatusAbility.Agility] += (int) CurrentXP[StatusAbility.Agility];
            CurrentXP[StatusAbility.Agility] -= (int) CurrentXP[StatusAbility.Agility];

            CurrentStatus[StatusAbility.Magic] += (int) CurrentXP[StatusAbility.Magic];
            CurrentXP[StatusAbility.Magic] -= (int) CurrentXP[StatusAbility.Magic];
        }

        public void AddXP(EnemyStats enemyStats)
        {
            LevelXP += (int) (enemyStats.XPAmount * Mathf.Pow(10, enemyStats.Level - Level));
            // gleiches level -> *10^0 = 1 | enemy level eins kleiner -> *10^-1 | grösser *10^1 etc.
        }
    }
}