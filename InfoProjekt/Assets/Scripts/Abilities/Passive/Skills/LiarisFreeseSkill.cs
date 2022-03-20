using IO;
using Player;
using Player.Stats;
using UnityEngine;

namespace Abilities.Passive.Skills
{
    [CreateAssetMenu(menuName = "Abilities/Passive/Skills/Liaris Freese", fileName = "Liaris Freese")]
    public class LiarisFreeseSkill: PassiveAbility
    {
        private const float XPMultiplier = 1f;
        
        public override void Init(GameObject parentObject, Stats playerStats)
        {
            playerStats.XPManager.UniversalXPMultiplier = XPMultiplier;
        }

        public override void Update()
        {
            
        }
    }
}