using Player.Stats;
using UnityEngine;

namespace Abilities.Passive.DevelopmentAbilities
{
    [CreateAssetMenu(menuName = "Abilities/Passive/Development Ability/Hunter", fileName = "Hunter")]
    public class HunterAbility: DevelopmentAbility
    {
        public override void Init(GameObject parentObject, PlayerStats playerStats)
        {
            name = "Hunter";
            rank = StatusRank.I;
            parent = parentObject;
            stats = playerStats;
        }

        public override void Update()
        {
            
        }
    }
}