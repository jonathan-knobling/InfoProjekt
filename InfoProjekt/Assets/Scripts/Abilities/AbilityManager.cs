using Abilities.Active;
using Abilities.Passive;
using IO;
using Player;
using Player.Stats;
using UnityEngine;

namespace Abilities
{
    [RequireComponent(typeof(Stats))]
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private InputChannelSO inputChannel;
        [SerializeField] private ActiveAbility[] activeAbilities;
        [SerializeField] private PassiveAbility[] passiveAbilities;

        private Stats stats;
        
        private void Start()
        {
            stats = GetComponent<Stats>();
            
            foreach (var ability in activeAbilities)
            {
                ability.Init(inputChannel, gameObject);
            }

            foreach (var ability in passiveAbilities)
            {
                ability.Init(gameObject, stats);
            }
        }

        void Update()
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
