using Tech;
using Tech.IO.PlayerInput;
using UnityEngine;
using Util;

namespace Gameplay.Abilities.Active.Skills
{
    [CreateAssetMenu(menuName = "Abilities/Active/Skills/Dash", fileName = "Dash")]
    public class DashAbility : ActiveAbility
    {
        [SerializeField] private float dashForce = 100f;
        private EventChannelSO eventChannel;
        private InputMiddleWare inputMiddleWare;
        private Rigidbody2D rb;

        public DashAbility()
        {
            maxCooldownTime = 7.5f;
            maxActiveTime = 0f;
        }

        public override void Init(EventChannelSO eventChannelSO, GameObject parentObject, AbilityManager abilityManager)
        {
            eventChannel = eventChannelSO;
            eventChannelSO.InputChannel.OnSkill1ButtonPressed += OnSkillButtonPressed;
            rb = parentObject.GetComponent<Rigidbody2D>();

            inputMiddleWare = new InputMiddleWare();
            eventChannelSO.InputChannel.InputProvider.AddMiddleWare(inputMiddleWare,1);
        }

        public override void Update()
        {
            State.Update();
            Debug.Log(inputMiddleWare.InputState.enabled);
            if (inputMiddleWare.InputState.enabled && rb.velocity.magnitude <= eventChannel.PlayerChannel.MaxVelocity)
            {
                inputMiddleWare.Disable();
                rb.drag = 0;
            }
        }

        private void OnSkillButtonPressed()
        {
            if (State.Equals(ReadyState))
            {
                State = ActiveState;
                ActiveState.Activate();

                //Calculate Direction
                Vector2 direction = eventChannel.InputChannel.InputProvider.GetState().InputDirection.value;
                direction.Normalize();

                inputMiddleWare.InputState = new Optional<InputState>
                {
                    enabled = true,
                    value = new InputState(direction, true, true, 20)
                };

                direction *= dashForce;
                rb.AddForce(direction, ForceMode2D.Impulse);
            }
        }
    }
}
