using Player.Stats;

namespace Abilities.Passive
{
    public abstract class DevelopmentAbility: PassiveAbility
    {
        protected StatusRank rank;
        public StatusRank Rank => rank;
    }
}
