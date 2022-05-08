using Actors.Player.Stats;
using UnityEngine;

namespace Gameplay.Abilities.Passive.Skills
{
    [CreateAssetMenu(menuName = "Abilities/Passive/Skills/Liaris Freese", fileName = "Liaris Freese")]
    public class LiarisFreeseSkill: PassiveAbility
    {
        private const float XPMultiplier = 1f;

        public override void Init(GameObject parentObject, PlayerStats playerStats)
        {
            playerStats.XPManager.UniversalXPMultiplier = XPMultiplier;
        }

        public override void Update()
        {
            
        }
    }
}