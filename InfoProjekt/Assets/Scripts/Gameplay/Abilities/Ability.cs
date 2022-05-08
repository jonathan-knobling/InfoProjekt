using UnityEngine;

namespace Gameplay.Abilities
{
    public abstract class Ability: ScriptableObject
    {
        //public static string ActiveSkillAssetMenuPath => "Abilities/Active/Skill/";
        //public static string ActiveMagicAssetMenuPath => "Abilities/Active/Magic/";
        //public static string PassiveSkillAssetMenuPath => "Abilities/Passive/Skill/";
        //public static string PassiveDevAbilityAssetMenuPath => "Abilities/Passive/Development Ability/";

        public Sprite icon;
        
        public abstract void Update();
    }
}