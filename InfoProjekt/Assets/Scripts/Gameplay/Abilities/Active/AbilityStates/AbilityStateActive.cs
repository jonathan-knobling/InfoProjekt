using Util;

namespace Gameplay.Abilities.Active.AbilityStates
{
    public class AbilityStateActive: AbilityState
    {
        private Timer timer;
        private ActiveAbility parentAbility;
        
        public override void Update()
        {
            timer.Update();
        }

        public override void Activate(ActiveAbility ability)
        {
            timer = new Timer(ability.ActiveTime);
            parentAbility = ability;
            timer.OnElapsed += NextState;
        }

        private void NextState()
        {
            parentAbility.State = parentAbility.CooldownState;
            parentAbility.CooldownState.Activate(parentAbility);
        }
    }
}