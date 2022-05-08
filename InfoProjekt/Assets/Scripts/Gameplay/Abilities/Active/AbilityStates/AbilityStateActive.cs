using System;
using Util;

namespace Gameplay.Abilities.Active.AbilityStates
{
    public class AbilityStateActive: AbilityState
    {
        public Timer Timer;
        private readonly ActiveAbility parentAbility;

        public event Action OnEnterState;
        
        public AbilityStateActive(ActiveAbility ability)
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
            Timer = new Timer(parentAbility.MaxActiveTime);
            Timer.OnElapsed += NextState;
        }

        private void NextState()
        {
            parentAbility.State = parentAbility.CooldownState;
            parentAbility.CooldownState.Activate();
        }
    }
}