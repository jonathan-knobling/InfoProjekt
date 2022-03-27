using UnityEngine;

namespace Environment.Actors
{
    public abstract class Stats: MonoBehaviour, IDamagable
    {
        protected float Health;
        public int level;
        public float levelXP;
        public float maxHealth;
        public float attackDamage;
        public float speed;
        
        public abstract float DealDamage(float damage);
    }
}