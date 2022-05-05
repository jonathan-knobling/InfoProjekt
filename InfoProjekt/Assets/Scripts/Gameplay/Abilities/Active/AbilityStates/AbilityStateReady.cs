using System;

namespace Gameplay.Abilities.Active.AbilityStates
{
    public class AbilityStateReady: AbilityState
    {
        public event Action OnEnterState;
        
        public override void Update()
        {
            
        }

        public override void Activate()
        {
            OnEnterState?.Invoke();
        }
    }
}