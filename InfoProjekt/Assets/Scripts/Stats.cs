using System;
using UnityEngine;

public class Stats : MonoBehaviour
{
    //stats nach danmachi system

    private int level = 1;
    private const float levelMultiplier = 0.7f;                           //over
    private int[] xpThreshold = { 4, 8, 15, 16, 23, 42, 69, 420, 911, 1337, 9000, 69420 };

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
                                    || currentAgility >= 600 || currentMagic >= 600) && xp > xpThreshold[level-1];

    //Stats
    private float maxHP => endurance * 0.69420f; // balancen    
    private float hp;
    private float damage => strength * 0.69420f; // balancen

    void Start()
    {
        hp = maxHP;
    }

    public void LevelUp()
    {
        if (!levelUpPossible) return;
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

    public void addXP(int amount, Enemy enemy)
    {
        xp += (int) (amount * Mathf.Pow(10, enemy.GetLevel() - level)); 
        // gleiches level -> *10^0 = 1 | enemy level eins kleiner -> *10^-1 | grösser *10^1 etc. // bin ich schon bissl stolz drauf :)
    }

    public void addStrengthXP(float damage) //gegner durch meele attack zugefügtes damage vor att multiplier
    {
        strengthXP += (int)(damage * 0.69420f); // balancen
    }

    public void addEnduranceXP(float damage) //receivetes damage von egal welcher attacke vor def multiplier
    {
        enduranceXP += (int)(damage * 0.69420f); // balancen
    }

    public void addDexterityXP(float damage) //geblocktes damage vor att multiplier (evtl auch noch andere möglichkeiten die was mit geschicklichkeit zum tun haben)
    {
        dexterityXP += (int)(damage * 0.69420f); // balancen
    }

    public void addMagicXP(float damage) //gegner durch magic attack zugefügtes damage vor att multiplier
    {
        magicXP += (int)(damage * 0.69420f); // balancen
    }

    public void addAgilityXP(float distance) //distance die man gelaufen is vllt oder was anderes keine ahnung wie man des machen kann
    {
        agilityXP += (int)(distance * 0.69420f); // balancen
    }

    public void dealDamage(float damage)
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
        //löschen
    }

    public float getAttDmg()
    {
        return damage;
    }

    public float getMaxHP()
    {
        return maxHP;
    }

    public int getLevel()
    {
        return level;
    }
}