namespace Environment.Actors.Enemies.EnemyAI
{
    public abstract class EnemyState
    {
        protected string Name;
        public abstract void Update(Environment.Actors.Enemies.EnemyAI.EnemyAI enemyAI);
        public abstract void EnterState(Environment.Actors.Enemies.EnemyAI.EnemyAI enemyAI);
    }
}
