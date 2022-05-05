using Tech;
using UnityEngine;

namespace Gameplay.Abilities.Active.Skills
{
    [CreateAssetMenu(menuName = "Abilities/Active/Skills/Dash", fileName = "Dash")]
    public class DashAbility : ActiveAbility
    {
        private float dashForce;

        public DashAbility()
        {
            name = "dash";
            maxCooldownTime = 7.5f;
            maxActiveTime = 0f;
        }

        public override void Init(EventChannelSO eventChannel, GameObject parentObject, AbilityManager abilityManager)
        {
            eventChannel.InputChannel.OnSkill1ButtonPressed += OnSkillButtonPressed;
            Parent = parentObject;
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
                Vector2 direction = rb.velocity;
                // vector = 1
                direction.Normalize();
                // mit dashforce multiplizieren
                direction *= dashForce;
                // force adden
                rb.AddForce(direction, ForceMode2D.Impulse);
            }
        }
    }
}
