using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Channels/Player Movement Channel")]
    public class PlayerMovementChannelSO: ScriptableObject
    {
        private readonly List<PlayerMovementController> controllers;

        public event Action OnSetIdle;

        public PlayerMovementChannelSO()
        {
            controllers = new List<PlayerMovementController>();
        }
        
        public void AddPlayerMovementController(PlayerMovementController controller)
        {
            controllers.Add(controller);
        }

        public void DisablePlayerMovement()
        {
            foreach (var controller in controllers)
            {
                controller.enabled = false;
            }
        }

        public void EnablePlayerMovement()
        {
            foreach (var controller in controllers)
            {
                controller.enabled = true;
            }
        }

        public void SetIdle()
        {
            OnSetIdle?.Invoke();
        }
    }
}