namespace Enemies.EnemyAI
{
    public abstract class EnemyState
    {
        public abstract void Update(EnemyAI enemyAI);
        public abstract void EnterState(EnemyAI enemyAI);
    }
}
