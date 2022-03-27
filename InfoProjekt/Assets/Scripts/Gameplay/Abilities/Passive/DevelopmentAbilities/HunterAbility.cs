using Environment.Actors.Player.Stats;
using UnityEngine;

namespace Gameplay.Abilities.Passive.DevelopmentAbilities
{
    [CreateAssetMenu(menuName = "Abilities/Passive/Development Ability/Hunter", fileName = "Hunter")]
    public class HunterAbility: DevelopmentAbility
    {
        public override void Init(GameObject parentObject, PlayerStats playerStats)
        {
            name = "Hunter";
            rank = StatusRank.I;
            Parent = parentObject;
            Stats = playerStats;
        }

        public override void Update()
        {
            
        }
    }
}