using System.Collections.Generic;
using Actors.Player.Stats;
using Gameplay.Abilities.Active;
using Gameplay.Abilities.Passive;
using Tech;
using Tech.IO;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Gameplay.Abilities
{
    [RequireComponent(typeof(PlayerStats))]
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private EventChannelSO eventChannel;

        private List<ActiveAbility> activeAbilities;
        private List<PassiveAbility> passiveAbilities;

        public List<ActiveAbility> ActiveAbilities => activeAbilities;
        public List<PassiveAbility> PassiveAbilities => passiveAbilities;
        
        private void Start()
        {
            var stats = GetComponent<PlayerStats>();
            
            foreach (var ability in activeAbilities)
            {
                ability.Init(eventChannel, gameObject, this);
            }

            foreach (var ability in passiveAbilities)
            {
                ability.Init(gameObject, stats);
            }
        }

        private void Update()
        {
            foreach (var ability in activeAbilities)
            {
                ability.Update();
            }

            foreach (var ability in passiveAbilities)
            {
                ability.Update();
            }
        }
    }
}
