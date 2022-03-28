using Gameplay.Abilities.Active.AbilityStates;
using Tech.IO;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Gameplay.Abilities.Active
{
    public abstract class ActiveAbility: ScriptableObject
    {

        protected new string name;
        protected float cooldownTime;
        protected float activeTime;
        protected GameObject parent;
        
        protected internal AbilityState State { get; set; }
        protected internal AbilityStateReady ReadyState { get; }
        protected internal AbilityStateCooldown CooldownState { get; }
        protected AbilityStateActive ActiveState { get; }

        //getter
        public string Name => name;
        public float CooldownTime => cooldownTime;
        public float ActiveTime => activeTime;

        protected ActiveAbility()
        {
            ReadyState = new AbilityStateReady();
            ActiveState = new AbilityStateActive();
            CooldownState = new AbilityStateCooldown();
            State = ReadyState;
            ReadyState.Activate(this);
        }

        public abstract void Init(InputChannelSO inputChannel, GameObject parentObject);
        public abstract void Update();
    }
}
