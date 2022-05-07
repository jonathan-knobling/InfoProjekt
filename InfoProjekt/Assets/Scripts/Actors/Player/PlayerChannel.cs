using System;

namespace Actors.Player
{
    public class PlayerChannel
    {
        public event Action<string> OnEnemyKilled;

        public float Velocity { get; set; }
        public float MaxVelocity { get; set; }

        //Combat
        public void EnemyKilled(string enemyID)
        {
            OnEnemyKilled?.Invoke(enemyID);
        }
    }
}