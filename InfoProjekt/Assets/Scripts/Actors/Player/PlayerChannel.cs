using System;
using System.Collections.Generic;

namespace Actors.Player
{
    public class PlayerChannel
    {
        private readonly List<PlayerMovementController> movementControllers;
        private readonly List<PlayerCombatController> combatControllers;

        public event Action OnSetIdle;
        public event Action<string> OnEnemyKilled;

        public float Velocity { get; set; }

        public PlayerChannel()
        {
            movementControllers = new List<PlayerMovementController>();
            combatControllers = new List<PlayerCombatController>();
        }
        
        //Movement
        public void AddPlayerMovementController(PlayerMovementController controller)
        {
            movementControllers.Add(controller);
        }

        public void DisablePlayerMovement()
        {
            foreach (var controller in movementControllers)
            {
                controller.enabled = false;
            }
        }

        public void EnablePlayerMovement()
        {
            foreach (var controller in movementControllers)
            {
                controller.enabled = true;
            }
        }

        public void MovementSetIdle()
        {
            OnSetIdle?.Invoke();
        }
        
        
        //Combat
        public void EnemyKilled(string enemyID)
        {
            OnEnemyKilled?.Invoke(enemyID);
        }

        public void AddPlayerCombatController(PlayerCombatController controller)
        {
            combatControllers.Add(controller);
        }

        public void DisablePlayerCombat()
        {
            foreach (var controller in combatControllers)
            {
                controller.enabled = false;
            }
        }

        public void EnablePlayerCombat()
        {
            foreach (var controller in combatControllers)
            {
                controller.enabled = true;
            }
        }
    }
}