public abstract class EnemyState
{
    public abstract void Update(EnemyAI enemyAI, Enemy stats);
    public abstract void EnterState(EnemyAI enemyAI, Enemy stats);
}
