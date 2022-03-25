using Enemies;
using UnityEngine;

namespace Player.Stats
{
    [RequireComponent(typeof(Animator))]
    public class PlayerStats : MonoBehaviour
    {
        private static readonly int CPDeath = Animator.StringToHash("death");
        private Animator animator;

        //Movement Variables
        [SerializeField] private float speed = 10;
        [SerializeField] private float jumpForce = 20;
        
        //stats nach danmachi system
        private const float LevelMultiplier = 0.7f;                                      //over
        private readonly int[] xpThreshold = {0, 4, 8, 15, 16, 23, 42, 69, 420, 911, 1337, 9000, 69420};

        //Current Status
        private int currentAgility = 10;
        private int currentDexterity = 10;
        private int currentEndurance = 10;
        private int currentMagic = 10;
        private int currentStrength = 10;
        
        //Hidden Status
        private int hiddenStrength;
        private int hiddenAgility;
        private int hiddenDexterity;
        private int hiddenEndurance;
        private int hiddenMagic;
        
        //Current XP
        private float magicXP;
        private float strengthXP;
        private float dexterityXP;
        private float enduranceXP;
        private float agilityXP;

        //Stats
        private float hp;

        public StatsXPManager XPManager { get; private set; }

        public float Speed => speed;
        public float JumpForce => jumpForce;

        //Total Status
        private float Strength => (currentStrength + hiddenStrength) * Level * LevelMultiplier;
        private float Endurance => (currentEndurance + hiddenEndurance) * Level * LevelMultiplier;
        private float Dexterity => (currentDexterity + hiddenDexterity) * Level * LevelMultiplier;
        private float Agility => (currentAgility + hiddenAgility) * Level * LevelMultiplier;
        private float Magic => (currentMagic + hiddenMagic) * Level * LevelMultiplier;
        private float MaxHP => Endurance * 0.69420f; // balancen    

        //getter
        public float AttackDamage => Strength * 0.69420f; // balancen
        public int Level { get; private set; } = 1;
        public float LevelXP { get; private set; }

        public int[] CurrentStats => new[] 
            {currentStrength, currentEndurance, currentDexterity, currentAgility, currentMagic};
        
        public float[] CurrentXP => new[] 
            {strengthXP, enduranceXP, dexterityXP, agilityXP, magicXP};

        public int[] HiddenStats => new[] 
            {hiddenStrength, hiddenEndurance, hiddenDexterity, hiddenAgility, hiddenMagic};

        public float[] TotalStats => new[] 
            {Strength, Endurance, Dexterity, Agility, Magic};

        public bool LevelUpPossible => 
            (currentStrength >= 600 || currentEndurance >= 600 || currentDexterity >= 600 
             || currentAgility >= 600 || currentMagic >= 600) && LevelXP > xpThreshold[Level];

        public bool StatusUpdatePossible =>
            strengthXP > 0 || enduranceXP > 0 || dexterityXP > 0 || agilityXP > 0 || magicXP > 0;

        private void Start()
        {
            hp = MaxHP;
            XPManager = new StatsXPManager(this);
            animator = GetComponent<Animator>();
        }

        public void LevelUp()
        {
            if (!LevelUpPossible) return;
            StatusUpdate();

            LevelXP -= xpThreshold[Level];
            Level++;
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
            LevelXP += (int) (enemy.XPAmount * Mathf.Pow(10, enemy.Level - Level));
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
                XPManager.AddReceivedDamage(damageAmount + hp);
                hp = 0;
                Die();
                return;
            }

            XPManager.AddReceivedDamage(damageAmount);
        }

        private void Die()
        {
            animator.SetTrigger(CPDeath);
            //vllt death screen oder so
            //löschen
        }
    }
}