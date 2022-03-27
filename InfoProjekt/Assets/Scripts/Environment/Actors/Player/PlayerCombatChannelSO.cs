using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Actors.Player
{
    [CreateAssetMenu(menuName = "Channels/Player Combat Channel")]
    public class PlayerCombatChannelSO: ScriptableObject
    {
        private readonly List<PlayerCombatController> controllers;
        
        public event Action<string> OnEnemyKilled;

        public PlayerCombatChannelSO()
        {
            controllers = new List<PlayerCombatController>();
        }

        public void EnemyKilled(string enemyID)
        {
            OnEnemyKilled?.Invoke(enemyID);
        }

        public void AddPlayerCombatController(PlayerCombatController controller)
        {
            controllers.Add(controller);
        }

        public void DisablePlayerCombat()
        {
            foreach (var controller in controllers)
            {
                controller.enabled = false;
            }
        }

        public void EnablePlayerCombat()
        {
            foreach (var controller in controllers)
            {
                controller.enabled = true;
            }
        }
    }
}