using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(menuName = "Channels/Player Combat Channel")]
    public class PlayerCombatChannelSO: ScriptableObject
    {
        public event Action<string> OnEnemyKilled;

        private List<PlayerCombatController> controllers;
        
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