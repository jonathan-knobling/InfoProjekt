using System;
using UnityEngine;

namespace IO
{
    public class PlayerInput: MonoBehaviour
    {
        public static PlayerInput Instance;
        
        [SerializeField] public InputChannelSO inputChannel;

        private void Start()
        {
            Instance = this;
        }

        private void Update()
        {
            inputChannel.horizontalDirection = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump"))
            {
                inputChannel.OnJumpButtonPressed();
            }

            if (Input.GetButtonDown("Hit"))
            {
                inputChannel.OnHitButtonPressed();
            }

            if (Input.GetButtonDown("Interact"))
            {
                inputChannel.OnInteractButtonPressed();
            }
            
            if (Input.GetButtonDown("Pause"))
            {
                inputChannel.OnPauseButtonPressed();
            }

            if (Input.GetButtonDown("Skill1"))
            {
               inputChannel.OnSkill1ButtonPressed();
            }
        }
    }
}