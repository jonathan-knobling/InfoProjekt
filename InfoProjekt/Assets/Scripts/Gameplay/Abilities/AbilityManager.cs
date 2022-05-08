using System.Collections.Generic;
using Actors.Player.Stats;
using Gameplay.Abilities.Active;
using Gameplay.Abilities.Passive;
using Tech;
using Tech.IO.Saves;
using UnityEngine;

namespace Gameplay.Abilities
{
    [RequireComponent(typeof(PlayerStats))]
    public class AbilityManager : MonoBehaviour, ISaveable
    {
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] private AbilityDatabaseSO abilityDatabase;

        [SerializeField] private List<ActiveAbility> activeAbilities;
        [SerializeField] private List<PassiveAbility> passiveAbilities;

        public List<ActiveAbility> ActiveAbilities => activeAbilities;
        public List<PassiveAbility> PassiveAbilities => passiveAbilities;
        
        private void Start()
        {
            var stats = GetComponent<PlayerStats>();
            activeAbilities ??= new List<ActiveAbility>();
            passiveAbilities ??= new List<PassiveAbility>();
            
            foreach (var ability in activeAbilities)
            {
                ability.Init(eventChannel, gameObject, this);
            }

            foreach (var ability in passiveAbilities)
            {
                ability.Init(gameObject, stats, eventChannel);
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
        

        //Serialization
        public object SerializeComponent()
        {
            var passives = new Dictionary<string, object>();
            var actives = new Dictionary<string, object>();

            foreach (var ability in passiveAbilities)
            {
                passives.TryAdd(ability.id, ability.SerializeComponent());
            }

            foreach (var ability in activeAbilities)
            {
                actives.TryAdd(ability.id, ability.SerializeComponent());
            }
            
            return new SaveData()
            {
                PassiveAbilities = passives,
                ActiveAbilities = actives
            };
        }

        public void ApplySerializedData(object serializedData)
        {
            var data = (SaveData) serializedData;

            foreach (var (key, value) in data.PassiveAbilities)
            {
                abilityDatabase.PassiveAbilities.TryGetValue(key, out var ability);
                
                if (ability == null) continue;
                
                ability.ApplySerializedData(value);
                passiveAbilities.Add(ability);
            }

            foreach (var (key, value) in data.ActiveAbilities)
            {
                abilityDatabase.ActiveAbilities.TryGetValue(key, out var ability);
                
                if (ability == null) continue;
                
                ability.ApplySerializedData(value);
                activeAbilities.Add(ability);
            }
        }

        private struct SaveData
        {
            public Dictionary<string, object> PassiveAbilities;
            public Dictionary<string, object> ActiveAbilities;
        }
    }
}
