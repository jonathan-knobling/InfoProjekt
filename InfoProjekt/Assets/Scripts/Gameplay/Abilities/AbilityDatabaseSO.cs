using System.Collections.Generic;
using System.Linq;
using Gameplay.Abilities.Active;
using Gameplay.Abilities.Passive;
using UnityEngine;

namespace Gameplay.Abilities
{
    [CreateAssetMenu(menuName = "Databases/Ability Database", fileName = "Ability Database")]
    public class AbilityDatabaseSO: ScriptableObject
    {
        [SerializeField] private List<PassiveAbility> passiveAbilities;
        [SerializeField] private List<ActiveAbility> activeAbilities;

        public Dictionary<string, PassiveAbility> PassiveAbilities => passiveAbilities.ToDictionary(ability => ability.id);
        public Dictionary<string, ActiveAbility> ActiveAbilities => activeAbilities.ToDictionary(ability => ability.id);
    }
}