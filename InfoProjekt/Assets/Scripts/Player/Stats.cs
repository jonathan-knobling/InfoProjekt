using Enemies;
using UnityEngine;

namespace Player
{
    public class Stats : MonoBehaviour
    {
        //stats nach danmachi system
        private int level = 1;
        private const float levelMultiplier = 0.7f;                           //over
        private int[] xpThreshold = { 0, 4, 8, 15, 16, 23, 42, 69, 420, 911, 1337, 9000, 69420 };

        private int xp = 0;
        private int strengthXP = 0;
        private int enduranceXP = 0;
        private int dexterityXP = 0;
        private int agilityXP = 0;
        private int magicXP = 0;

        [Header("Current Status")]
        private int currentStrength = 10;
        private int currentEndurance = 10;
        private int currentDexterity = 10;
        private int currentAgility = 10;
        private int currentMagic = 10;

        [Header("Hidden Status")]
        private int hiddenStrength = 0;
        private int hiddenEndurance = 0;
        private int hiddenDexterity = 0;
        private int hiddenAgility = 0;
        private int hiddenMagic = 0;

        //Total Status
        private float strength => (currentStrength + hiddenStrength) * level * levelMultiplier;
        private float endurance => (currentEndurance + hiddenEndurance) * level * levelMultiplier;
        private float dexterity => (currentDexterity + hiddenDexterity) * level * levelMultiplier;
        private float agility => (currentAgility + hiddenAgility) * level * levelMultiplier;
        private float magic => (currentMagic + hiddenMagic) * level * levelMultiplier;

        private bool levelUpPossible => (currentStrength >= 600 || currentEndurance >= 600 || currentDexterity >= 600
                                         || currentAgility >= 600 || currentMagic >= 600) && xp > xpThreshold[level];

        private bool statusUpdatePossible => strengthXP > 0 || enduranceXP > 0 || dexterityXP > 0 || agilityXP > 0 || magicXP > 0;

        //Stats
        private float maxHP => endurance * 0.69420f; // balancen    
        private float hp;
        private float damage => strength * 0.69420f; // balancen
        
        //getter
        public float AttackDamage => damage;
        public float MaxHP => maxHP;
        public int Level => level;
        public int[] CurrentStats => new int[] {currentStrength, currentEndurance, currentDexterity, currentAgility, currentMagic};
        public int[] CurrentXP => new int[] { strengthXP, enduranceXP, dexterityXP, agilityXP, magicXP };
        public int LevelXP => xp;
        public int[] HiddenStats => new int[] { hiddenStrength, hiddenEndurance, hiddenDexterity, hiddenAgility, hiddenMagic };
        public float[] TotalStats => new float[] { strength, endurance, dexterity, agility, magic};
        public bool LevelUpPossible => levelUpPossible;
        public bool StatusUpdatePossible => statusUpdatePossible;

        void Start()
        {
            hp = maxHP;
        }

        public void LevelUp()
        {
            if (!levelUpPossible) return;
            statusUpdate();

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

        public void statusUpdate()
        {
            if (!statusUpdatePossible) return;

            currentStrength += strengthXP;
            strengthXP = 0;
            currentEndurance += enduranceXP;
            enduranceXP = 0;
            currentDexterity += dexterityXP;
            dexterityXP = 0;
            currentAgility += agilityXP;
            agilityXP = 0;
            currentMagic += magicXP;
            magicXP = 0;
        }

        public void AddXp(EnemyStats enemy)
        {
            xp += (int) (enemy.XPAmount * Mathf.Pow(10, enemy.Level - level)); 
            // gleiches level -> *10^0 = 1 | enemy level eins kleiner -> *10^-1 | gr�sser *10^1 etc. // bin ich schon bissl stolz drauf :)
        }

        public void AddStrengthXp(float damage) //gegner durch meele attack zugef�gtes damage vor att multiplier
        {
            strengthXP += (int)(damage * 0.69420f); // balancen
        }

        public void AddEnduranceXp(float damage) //receivetes damage von egal welcher attacke vor def multiplier
        {
            enduranceXP += (int)(damage * 0.69420f); // balancen
        }

        public void AddDexterityXp(float damage) //geblocktes damage vor att multiplier (evtl auch noch andere m�glichkeiten die was mit geschicklichkeit zum tun haben)
        {
            dexterityXP += (int)(damage * 0.69420f); // balancen
        }

        public void AddMagicXp(float damage) //gegner durch magic attack zugef�gtes damage vor att multiplier
        {
            magicXP += (int)(damage * 0.69420f); // balancen
        }

        public void AddAgilityXp(float distance) //distance die man gelaufen is vllt oder was anderes keine ahnung wie man des machen kann
        {
            agilityXP += (int)(distance * 0.69420f); // balancen
        }

        public void DealDamage(float damage)
        {
            this.hp -= damage; // hier noch def multiplier vllt
            if (hp <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //death animation
            //vllt death screen oder so
            //l�schen
        }
    }
}