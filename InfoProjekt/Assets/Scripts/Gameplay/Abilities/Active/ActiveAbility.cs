using Gameplay.Abilities.Active.AbilityStates;
using Tech;
using UnityEngine;

namespace Gameplay.Abilities.Active
{
    public abstract class ActiveAbility: ScriptableObject
    {
        public float cooldownTime { get; protected set; }
        public float activeTime { get; protected set; }
        protected GameObject Parent { get; set; }
        
        protected internal AbilityState State { get; set; }
        protected internal AbilityStateReady ReadyState { get; }
        protected internal AbilityStateCooldown CooldownState { get; }
        protected AbilityStateActive ActiveState { get; }

        protected ActiveAbility()
        {
            ReadyState = new AbilityStateReady();
            ActiveState = new AbilityStateActive();
            CooldownState = new AbilityStateCooldown();
            State = ReadyState;
            ReadyState.Activate(this);
        }

        public abstract void Init(EventChannelSO eventChannel, GameObject parentObject);
        public abstract void Update();
    }
}
