using System;
using UnityEngine;

namespace IO
{
    public class PlayerInput: MonoBehaviour
    {
        [SerializeField] public InputChannelSO inputChannel;

        private void Update()
        {
            inputChannel.HorizontalDirection = Input.GetAxisRaw("Horizontal");

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
                inputChannel.PauseButtonPressed();
            }

            if (Input.GetButtonDown("Skill1"))
            {
               inputChannel.Skill1ButtonPressed();
            }
        }
    }
}