using System;
using Util;

namespace Gameplay.Abilities.Active.AbilityStates
{
    public class AbilityStateCooldown: AbilityState
    {
        public Timer Timer;
        private readonly ActiveAbility parentAbility;

        public event Action OnEnterState;
        
        public AbilityStateCooldown(ActiveAbility ability)
        {
            parentAbility = ability;
        }
        
        public override void Update()
        {
            Timer.Update();
        }

        public override void Activate()
        {
            OnEnterState?.Invoke();
            Timer = new Timer(parentAbility.MaxCooldownTime);
            Timer.OnElapsed += NextState;
        }

        private void NextState()
        {
            parentAbility.State = parentAbility.ReadyState;
            parentAbility.ReadyState.Activate();
        }
    }
}