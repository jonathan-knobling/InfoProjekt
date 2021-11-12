using System.Linq.Expressions;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [Header("Ranking")]
    [SerializeField] private int mp = 1_000;
    private Rank rank;

    [Header("Stats Multiplier")]
    [SerializeField] private float healthMultiplier = 1;// für diese person / monster was auch immer spezifisch
    [SerializeField] private float attackMultiplier = 1;
    private const float baseHealthMultiplier = 4.5f; // für jeden der stats hat
    private const float baseattackMultiplier = 1;
    
    private float maxHealth => mp * baseHealthMultiplier * healthMultiplier; // lambdas sind op
    private float attack => mp * baseattackMultiplier* attackMultiplier;

    private float currentHealth;

    enum Rank
    {
        E, D, C, B, Bplus, Aminus, A, Aplus
    }

    void Start()
    {
        evaluateRank();
        currentHealth = maxHealth;
    }

    void takeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            GetComponent<Entity>().die();
        }
    }

    void addMP(int mp)
    {
        this.mp += mp;
        evaluateRank();
    }

    private void evaluateRank()
    {
        if (mp < 1_000)
        {
            rank = Rank.E;
        }
        else if (mp < 3_000)
        {
            rank = Rank.D;
        }
        else if (mp < 6_000)
        {
            rank = Rank.C;
        }
        else if (mp < 8_000)
        {
            rank = Rank.B;
        }
        else if (mp < 9_000)
        {
            rank = Rank.Bplus;
        }
        else if (mp < 10_000)
        {
            rank = Rank.Aminus;
        }
        else if (mp > 10_000 && mp < 100_000)
        {
            rank = Rank.A;
        }
        else if (mp > 100_000)
        {
            rank = Rank.Aplus;
        }
        Debug.Log(gameObject.name + ": Rank " + rank);
    }
}
/*Aus Tensei shitara slime datta ken :)
E  class <1,000
D  class 1,000 - <3,000
C  class 3,000 - <6,000
B  class 6,000 - <8,000
B+ class 8,000 - <9,000
A- class 9,000 - <10,000
A  class >10,000: Hazard class
Special A class >100,000: Calamity class*/