using Actors.Player.Stats;
using UnityEngine;

namespace Gameplay.Abilities.Passive
{
    public abstract class PassiveAbility: ScriptableObject
    {

        [SerializeField] protected new string name;
        protected GameObject Parent;
        protected PlayerStats Stats;
        
        //getter
        public string Name => name;

        public abstract void Init(GameObject parentObject, PlayerStats playerStats);
        public abstract void Update();
    }
}