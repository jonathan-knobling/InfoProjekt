using Util;

namespace Gameplay.Abilities.Active.AbilityStates
{
    public class AbilityStateCooldown: AbilityState
    {
        private Timer timer;
        private ActiveAbility parentAbility;
        
        public override void Update()
        {
            timer.Update();
        }

        public override void Activate(ActiveAbility ability)
        {
            parentAbility = ability;
            timer = new Timer(ability.CooldownTime);
            timer.OnElapsed += NextState;
        }

        public void NextState()
        {
            parentAbility.State = parentAbility.ReadyState;
            parentAbility.ReadyState.Activate(parentAbility);
        }
    }
}