using Actors.Player.Stats;
using Gameplay.Abilities.Active;
using Gameplay.Abilities.Passive;
using Tech.IO;
using Tech.IO.PlayerInput;
using UnityEngine;

namespace Gameplay.Abilities
{
    [RequireComponent(typeof(PlayerStats))]
    public class AbilityManager : MonoBehaviour
    {
        [SerializeField] private InputChannelSO inputChannel;
        [SerializeField] private ActiveAbility[] activeAbilities;
        [SerializeField] private PassiveAbility[] passiveAbilities;

        private PlayerStats stats;
        
        private void Start()
        {
            stats = GetComponent<PlayerStats>();
            
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
