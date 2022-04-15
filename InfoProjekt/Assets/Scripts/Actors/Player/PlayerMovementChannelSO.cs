using System;
using System.Collections.Generic;
using UnityEngine;

namespace Actors.Player
{
    [CreateAssetMenu(menuName = "Channels/Player Movement Channel")]
    public class PlayerMovementChannelSO: ScriptableObject
    {
        private readonly List<MonoBehaviour> controllers;

        public event Action OnSetIdle;

        public PlayerMovementChannelSO()
        {
            controllers = new List<MonoBehaviour>();
        }
        
        public void AddPlayerMovementController(MonoBehaviour controller)
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