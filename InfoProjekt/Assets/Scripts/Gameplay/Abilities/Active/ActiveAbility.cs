using System;
using Gameplay.Abilities.Active.AbilityStates;
using Tech;
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

        public abstract void Init(EventChannelSO inputChannel, GameObject parentObject, AbilityManager abilityManager);
        
        public override object SerializeComponent()
        {
            AbilityStateEnum state = AbilityStateEnum.Ready;
            float remainingTime = 0f;

            switch (State)
            {
                case AbilityStateReady:
                    state = AbilityStateEnum.Ready;
                    break;
                case AbilityStateActive:
                    state = AbilityStateEnum.Active;
                    remainingTime = ActiveState.Timer.RemainingTime;
                    break;
                case AbilityStateCooldown:
                    state = AbilityStateEnum.Cooldown;
                    remainingTime = CooldownState.Timer.RemainingTime;
                    break;
            }

            return new SaveData
            {
                state = state,
                remainingTime = remainingTime
            };
        }

        public override void ApplySerializedData(object serializedData)
        {
            var data = (SaveData) serializedData;
            
            switch (data.state)
            {
                case AbilityStateEnum.Ready:
                    State = ReadyState;
                    break;
                case AbilityStateEnum.Active:
                    State = ActiveState;
                    ActiveState.Timer.SetRemainingTime(data.remainingTime);
                    break;
                case AbilityStateEnum.Cooldown:
                    State = CooldownState;
                    CooldownState.Timer.SetRemainingTime(data.remainingTime);
                    break;
            }
        }
        
        [Serializable]
        private struct SaveData
        {
            public AbilityStateEnum state;
            public float remainingTime;
        }

        [Serializable]
        private enum AbilityStateEnum
        {
            Active,
            Cooldown,
            Ready
        }
    }
}
