using Actors.Player.Stats;
using Tech;
using UnityEngine;

namespace Gameplay.Abilities.Passive
{
    public abstract class PassiveAbility: Ability
    {
        protected GameObject Parent;
        protected PlayerStats Stats;

        public abstract void Init(GameObject parentObject, PlayerStats playerStats, EventChannelSO eventChannel);
    }
}