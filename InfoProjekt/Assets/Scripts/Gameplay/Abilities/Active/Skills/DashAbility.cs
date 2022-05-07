using Tech;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Gameplay.Abilities.Active.Skills
{
    [CreateAssetMenu(menuName = "Abilities/Active/Skills/Dash", fileName = "Dash")]
    public class DashAbility : ActiveAbility
    {
        [SerializeField] private float dashForce = 200f;
        private EventChannelSO eventChannel;

        public DashAbility()
        {
            maxCooldownTime = 7.5f;
            maxActiveTime = 0f;
        }

        public override void Init(EventChannelSO eventChannelSO, GameObject parentObject, AbilityManager abilityManager)
        {
            eventChannelSO.InputChannel.OnSkill1ButtonPressed += OnSkillButtonPressed;
            Parent = parentObject;
            eventChannel = eventChannelSO;
        }

        public override void Update()
        {
            State.Update();
        }

        private void OnSkillButtonPressed()
        {
            if (State.Equals(ReadyState))
            {
                State = ActiveState;
                ActiveState.Activate();
                Rigidbody2D rb = Parent.GetComponent<Rigidbody2D>();
                //bewegungsrichtung getten
                Vector2 direction = eventChannel.InputChannel.InputProvider.GetState().InputDirection.value;
                // vector = 1
                Debug.Log(direction);
                direction.Normalize();
                // mit dashforce multiplizieren
                Debug.Log(direction);
                direction *= dashForce;
                // force adden
                Debug.Log(direction);
                rb.AddForce(direction, ForceMode2D.Impulse);
            }
        }
    }
}
