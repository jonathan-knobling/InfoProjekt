namespace Actors.Enemies.EnemyAI
{
    public abstract class EnemyState
    {
        protected string Name;
        public abstract void Update(global::Actors.Enemies.EnemyAI.EnemyAI enemyAI);
        public abstract void EnterState(global::Actors.Enemies.EnemyAI.EnemyAI enemyAI);
    }
}
