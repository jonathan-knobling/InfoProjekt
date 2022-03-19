using IO;
using UnityEngine;

namespace Skills.Active.Skills
{
    [CreateAssetMenu(menuName = "Skills/Active/Dash", fileName = "Dash")]
    public class DashSkill : ActiveSkill
    {
        private float dashForce;

        public DashSkill()
        {
            name = "dash";
            cooldownTime = 7.5f;
            activeTime = 0f;
        }

        public override void Init(InputChannelSO inputChannel, GameObject parent)
        {
            inputChannel.Skill1ButtonPressed += OnSkillButtonPressed;
            Parent = parent;
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
