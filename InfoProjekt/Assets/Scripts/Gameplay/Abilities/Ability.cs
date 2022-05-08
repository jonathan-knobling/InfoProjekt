using Tech.IO.Saves;
using UnityEngine;

namespace Gameplay.Abilities
{
    public abstract class Ability: ScriptableObject, ISaveable
    {
        //public static string ActiveSkillAssetMenuPath => "Abilities/Active/Skill/";
        //public static string ActiveMagicAssetMenuPath => "Abilities/Active/Magic/";
        //public static string PassiveSkillAssetMenuPath => "Abilities/Passive/Skill/";
        //public static string PassiveDevAbilityAssetMenuPath => "Abilities/Passive/Development Ability/";

        public string id;
        public Sprite icon;
        
        public abstract void Update();
        public abstract object SerializeComponent();
        public abstract void ApplySerializedData(object serializedData);
    }
}