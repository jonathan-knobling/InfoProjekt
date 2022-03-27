namespace Gameplay.Abilities.Active.AbilityStates
{
    public abstract class AbilityState
    {
        public abstract void Update();
        public abstract void Activate(ActiveAbility ability);
    }
}