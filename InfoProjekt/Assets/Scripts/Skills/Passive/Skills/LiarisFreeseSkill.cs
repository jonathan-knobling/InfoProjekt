using IO;
using Player;
using UnityEngine;

namespace Skills.Passive.Skills
{
    [CreateAssetMenu(menuName = "Skills/Passive/Liaris Freese", fileName = "Liaris Freese")]
    public class LiarisFreeseSkill: PassiveSkill
    {
        private const float XPMultiplier = 1f;
        
        public override void Init(InputChannelSO inputChannel, GameObject parentObject, Stats playerStats)
        {
            playerStats.XPManager.UniversalXPMultiplier = XPMultiplier;
        }

        public override void Update()
        {
            
        }
    }
}