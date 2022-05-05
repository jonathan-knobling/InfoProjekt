using Gameplay.Abilities.Active.AbilityStates;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Gameplay.Abilities.Active
{
    public abstract class ActiveAbility: Ability
    {
        [SerializeField] protected float maxCooldownTime;
        [SerializeField] protected float maxActiveTime;
        protected GameObject Parent;

        public float CurCooldownTime => CooldownState.Timer.ElapsedTime;
        public float CurActiveTime => ActiveState.Timer.ElapsedTime;
        public float MaxCooldownTime => maxCooldownTime;
        public float MaxActiveTime => maxActiveTime;
        public float CooldownPercentage => CurCooldownTime / MaxCooldownTime * 100;
        public float ActiveTimePercentage => CurActiveTime / MaxActiveTime * 100;

        public AbilityState State { get; protected internal set; }
        protected internal AbilityStateReady ReadyState { get; }
        protected internal AbilityStateCooldown CooldownState { get; }
        protected internal AbilityStateActive ActiveState { get; }

        protected ActiveAbility()
        {
            ReadyState = new AbilityStateReady();
            ActiveState = new AbilityStateActive(this);
            CooldownState = new AbilityStateCooldown(this);
            State = ReadyState;
            ReadyState.Activate();
        }

        public abstract void Init(InputChannelSO inputChannel, GameObject parentObject, AbilityManager abilityManager);
    }
}
