namespace Enemies.EnemyAI
{
    public abstract class EnemyState
    {
        public abstract void Update(EnemyAI enemyAI, EnemyStats stats);
        public abstract void EnterState(EnemyAI enemyAI, EnemyStats stats);
    }
}
