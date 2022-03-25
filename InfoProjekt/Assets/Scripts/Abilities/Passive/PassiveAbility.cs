using IO;
using Player.Stats;
using UnityEngine;

namespace Abilities.Passive
{
    public abstract class PassiveAbility: ScriptableObject
    {

        [SerializeField] protected new string name;
        protected GameObject parent;
        protected PlayerStats stats;
        
        //getter
        public string Name => name;

        public abstract void Init(GameObject parentObject, PlayerStats playerStats);
        public abstract void Update();
    }
}