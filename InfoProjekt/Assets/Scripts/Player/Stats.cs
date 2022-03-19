using System;
using Enemies;
using UnityEngine;

namespace Player
{
    public class Stats : MonoBehaviour
    {
        private StatsXPManager xpManager;
        public StatsXPManager XPManager => xpManager;
        
        //Movement Variables
        [SerializeField] private float speed = 10;        
        [SerializeField] private float jumpForce = 20;
        public float Speed => speed;
        public float JumpForce => jumpForce;

        //stats nach danmachi system
        private int level = 1;
        private const float LevelMultiplier = 0.7f;                                       //over
        private readonly int[] xpThreshold = { 0, 4, 8, 15, 16, 23, 42, 69, 420, 911, 1337, 9000, 69420 };

        //Current XP
        private float xp;
        private float strengthXP;
        private float enduranceXP;
        private float dexterityXP;
        private float agilityXP;
        private float magicXP;

        //Current Status
        private int currentStrength = 10;
        private int currentEndurance = 10;
        private int currentDexterity = 10;
        private int currentAgility = 10;
        private int currentMagic = 10;

        //Hidden Status
        private int hiddenStrength;
        private int hiddenEndurance;
        private int hiddenDexterity;
        private int hiddenAgility;
        private int hiddenMagic;

        //Total Status
        private float Strength => (currentStrength + hiddenStrength) * level * LevelMultiplier;
        private float Endurance => (currentEndurance + hiddenEndurance) * level * LevelMultiplier;
        private float Dexterity => (currentDexterity + hiddenDexterity) * level * LevelMultiplier;
        private float Agility => (currentAgility + hiddenAgility) * level * LevelMultiplier;
        private float Magic => (currentMagic + hiddenMagic) * level * LevelMultiplier;

        //Stats
        private float hp;
        private float MaxHP => Endurance * 0.69420f; // balancen    

        //getter
        public float AttackDamage => Strength * 0.69420f; // balancen
        public int Level => level;
        public int[] CurrentStats => new[] {currentStrength, currentEndurance, currentDexterity, currentAgility, currentMagic};
        public float[] CurrentXP => new[] { strengthXP, enduranceXP, dexterityXP, agilityXP, magicXP };
        public float LevelXP => xp;
        public int[] HiddenStats => new[] { hiddenStrength, hiddenEndurance, hiddenDexterity, hiddenAgility, hiddenMagic };
        public float[] TotalStats => new[] { Strength, Endurance, Dexterity, Agility, Magic};
        public bool LevelUpPossible => (currentStrength >= 600 || currentEndurance >= 600 || currentDexterity >= 600
                                        || currentAgility >= 600 || currentMagic >= 600) && xp > xpThreshold[level];
        public bool StatusUpdatePossible => strengthXP > 0 || enduranceXP > 0 || dexterityXP > 0 || agilityXP > 0 || magicXP > 0;

        void Start()
        {
            hp = MaxHP;
            xpManager = new StatsXPManager(this);
        }

        public void LevelUp()
        {
            if (!LevelUpPossible) return;
            StatusUpdate();

            xp -= xpThreshold[level];
            level++;
            hiddenStrength += currentStrength;
            currentStrength = 10;
            hiddenEndurance += currentEndurance;
            currentEndurance = 10;
            hiddenDexterity += currentDexterity;
            currentDexterity = 10;
            hiddenAgility += currentAgility;
            currentAgility = 10;
            hiddenMagic += currentMagic;
            currentMagic = 10;
        }

        public void StatusUpdate()
        {
            if (!StatusUpdatePossible) return;

            currentStrength += (int) strengthXP;
            strengthXP -= (int) strengthXP;
            
            currentEndurance += (int) enduranceXP;
            enduranceXP -= (int) enduranceXP;
            
            currentDexterity += (int) dexterityXP;
            dexterityXP -= (int) dexterityXP;
            
            currentAgility += (int) agilityXP;
            agilityXP -= (int) agilityXP;
            
            currentMagic += (int) magicXP;
            magicXP -= (int) magicXP;
        }

        public void AddXP(EnemyStats enemy)
        {
            xp += (int) (enemy.XPAmount * Mathf.Pow(10, enemy.Level - level)); 
            // gleiches level -> *10^0 = 1 | enemy level eins kleiner -> *10^-1 | grösser *10^1 etc.
            // bin ich schon bissl stolz drauf :)
        }

        //gegner durch meele attack zugefügtes damage vor att multiplier
        public void AddStrengthXP(float xpAmount) 
        {
            strengthXP += xpAmount;
        }

        //receivetes damage von egal welcher attacke vor def multiplier
        public void AddEnduranceXP(float xpAmount) 
        {
            enduranceXP += xpAmount;
        }
        
        //geblocktes damage vor att multiplier (evtl auch noch andere möglichkeiten die was mit geschicklichkeit zum tun haben)
        public void AddDexterityXP(float xpAmount) 
        {
            dexterityXP += xpAmount;
        }

        //gegner durch magic attack zugefügtes damage vor att multiplier
        public void AddMagicXP(float xpAmount) 
        {
            magicXP += xpAmount;
        }

        //distance die man gelaufen is vllt oder was anderes keine ahnung wie man des machen kann
        public void AddAgilityXP(float xpAmount) 
        {
            agilityXP += xpAmount;
        }

        public void DealDamage(float damageAmount)
        {
            hp -= damageAmount; // hier noch def multiplier vllt
            if (hp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //death animation
            //vllt death screen oder so
            //löschen
        }
    }
}