using System;
using UnityEngine;

namespace Environment.Actors
{
    public abstract class Stats: MonoBehaviour, IDamagable
    {
        protected float Health;
        protected float MaxHealth;
        [NonSerialized] public int Level;
        [NonSerialized] public float LevelXP;
        [NonSerialized] public float AttackDamage;
        [NonSerialized] public float Speed;
        
        public abstract float DealDamage(float damage);
    }
}