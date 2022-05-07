using System;
using UnityEngine;
using Util;

namespace Tech.IO.PlayerInput
{
    public class PlayerInput: MonoBehaviour
    {
        [SerializeField] public EventChannelSO eventChannel;

        private InputMiddleWare inputMiddleWare;

        private void Start()
        {
            inputMiddleWare = new InputMiddleWare();
            eventChannel.InputChannel.InputProvider.AddMiddleWare(inputMiddleWare, 0);
        }

        private void Update()
        {
            inputMiddleWare.InputState = new Optional<InputState>()
            {
                enabled = true,
                value = new InputState()
                {
                    InputDirection = new Optional<Vector2>()
                    {
                        enabled = true,
                        value = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"))
                    }
                }
            };
            
            //Debug.Log(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).ToString());
            //Debug.Log(inputMiddleWare.InputState.value.InputDirection.value.ToString());

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
                eventChannel.InputChannel.EscapeButtonPressed();
            }

            if (Input.GetButtonDown("Skill1"))
            {
                eventChannel.InputChannel.Skill1ButtonPressed();
            }
        }
    }
}