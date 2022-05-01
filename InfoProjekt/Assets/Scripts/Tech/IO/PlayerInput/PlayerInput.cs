using UnityEngine;

namespace Tech.IO.PlayerInput
{
    public class PlayerInput: MonoBehaviour
    {
        [SerializeField] public InputChannelSO inputChannel;

        private void Update()
        {
            inputChannel.InputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (Input.GetButtonDown("Jump"))
            {
                inputChannel.JumpButtonPressed();
            }

            if (Input.GetButtonDown("Hit"))
            {
                inputChannel.HitButtonPressed();
            }

            if (Input.GetButtonDown("Interact"))
            {
                inputChannel.InteractButtonPressed();
            }
            
            if (Input.GetButtonDown("Pause"))
            {
                inputChannel.EscapeButtonPressed();
            }

            if (Input.GetButtonDown("Skill1"))
            {
               inputChannel.Skill1ButtonPressed();
            }
        }
    }
}