using Actors.Player.Stats;

namespace Gameplay.Abilities.Passive
{
    public abstract class DevelopmentAbility: PassiveAbility
    {
        protected StatusRank rank;
        public StatusRank Rank => rank;
    }
}
