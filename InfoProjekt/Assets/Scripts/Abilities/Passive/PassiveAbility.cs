using IO;
using Player.Stats;
using UnityEngine;

namespace Abilities.Passive
{
    public abstract class PassiveAbility: ScriptableObject
    {

        [SerializeField] protected new string name;
        protected GameObject parent;
        protected Stats stats;
        
        //getter
        public string Name => name;

        public abstract void Init(GameObject parentObject, Stats playerStats);
        public abstract void Update();
    }
}