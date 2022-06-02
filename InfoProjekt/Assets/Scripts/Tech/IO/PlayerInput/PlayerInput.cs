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
                value = new InputState(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")), true, false)
            };

            if (Input.GetButtonDown("Hit"))
            {
                eventChannel.InputChannel.InputProvider.HitButtonPressed();
            }

            if (Input.GetButtonDown("Interact"))
            {
                eventChannel.InputChannel.InputProvider.InteractButtonPressed();
            }
            
            if (Input.GetButtonDown("Cancel"))
            {
                eventChannel.InputChannel.InputProvider.EscapeButtonPressed();
            }

            if (Input.GetButtonDown("OpenInv"))
            {
                eventChannel.InputChannel.InputProvider.OpenInvButtonPressed();
            }
                
            if (Input.GetButtonDown("Skill1"))
            {
                eventChannel.InputChannel.InputProvider.Skill1ButtonPressed();
            }
            
            if (Input.GetButtonDown("Skill2"))
            {
                eventChannel.InputChannel.InputProvider.Skill2ButtonPressed();
            }
            
            if (Input.GetButtonDown("Skill3"))
            {
                eventChannel.InputChannel.InputProvider.Skill3ButtonPressed();
            }
            
            if (Input.GetButtonDown("Skill4"))
            {
                eventChannel.InputChannel.InputProvider.Skill4ButtonPressed();
            }
        }
    }
}