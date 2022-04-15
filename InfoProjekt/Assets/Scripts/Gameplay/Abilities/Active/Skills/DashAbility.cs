using Tech.IO.PlayerInput;
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
            cooldownTime = 7.5f;
            activeTime = 0f;
        }

        public override void Init(InputChannelSO inputChannel, GameObject parentObject)
        {
            inputChannel.OnSkill1ButtonPressed += OnSkillButtonPressed;
            parent = parentObject;
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
                ActiveState.Activate(this);
                Rigidbody2D rb = parent.GetComponent<Rigidbody2D>();
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
