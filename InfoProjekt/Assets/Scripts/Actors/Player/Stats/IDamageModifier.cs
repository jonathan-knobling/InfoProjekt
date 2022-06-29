using Actors.Enemies;

namespace Actors.Player.Stats
{
    public interface IDamageModifier
    {
        float CalculateDamage(EnemyStats enemyStats, float baseDamage);
    }
}