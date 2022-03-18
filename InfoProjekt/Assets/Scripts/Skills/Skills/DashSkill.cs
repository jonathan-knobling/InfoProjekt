using IO;
using UnityEngine;

namespace Skills.Skills
{
    [CreateAssetMenu(fileName = "Dash", menuName = "Skills/Dash")]
    public class DashSkill : ActiveSkill
    {

        [SerializeField] private float dashForce = 10;

        public override void Init(InputChannelSO inputChannel, GameObject parent)
        {
            inputChannel.Skill1ButtonPressed += OnSkillButtonPressed;
            Parent = parent;
        }

        public override void Update()
        {
            State.Update();
        }

        public override void OnSkillButtonPressed()
        {
            if (State.Equals(ReadyState))
            {
                Rigidbody2D rb = Parent.GetComponent<Rigidbody2D>();
                //bewegungsrichtung getten
                Vector2 direction = rb.velocity;
                // vector = 1
                direction.Normalize();
                // mit dashforce multiplizieren
                direction *= dashForce;
                // force adden
                rb.AddForce(direction, ForceMode2D.Impulse);
                State = CooldownState;
                CooldownState.Activate(this);
            }
        }
    }
}
