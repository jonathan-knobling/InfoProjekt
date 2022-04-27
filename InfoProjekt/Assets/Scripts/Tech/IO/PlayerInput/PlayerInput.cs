using UnityEngine;

namespace Tech.IO.PlayerInput
{
    public class PlayerInput: MonoBehaviour
    {
        [SerializeField] public EventChannelSO eventChannel;

        private void Update()
        {
            eventChannel.InputChannel.InputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonDown("Jump"))
            {
                eventChannel.InputChannel.JumpButtonPressed();
            }

            if (Input.GetButtonDown("Hit"))
            {
                eventChannel.InputChannel.HitButtonPressed();
            }

            if (Input.GetButtonDown("Interact"))
            {
                eventChannel.InputChannel.InteractButtonPressed();
            }
            
            if (Input.GetButtonDown("Pause"))
            {
                eventChannel.InputChannel.PauseButtonPressed();
            }

            if (Input.GetButtonDown("Skill1"))
            {
                eventChannel.InputChannel.Skill1ButtonPressed();
            }
        }
    }
}