using UnityEngine;

public class EnemyRoamingState : EnemyState
{
    public override void EnterState(EnemyAI enemyAI, Enemy stats)
    {

    }

    public override void Update(EnemyAI enemyAI, Enemy stats)
    {
        


        Collider2D collider = enemyAI.checkView();
        if (collider != null)
        {
            enemyAI.changeState();
            enemyAI.setTarget(collider.GetComponent<GameObject>());
        }
    }
}