using UnityEngine;

namespace Actors.Enemies.EnemyAI
{
    public class EnemyController: MonoBehaviour
    {
        [SerializeField] private GameObject target;
        
        private EnemyStateHandler stateHandler;
        private EnemyMovementController movementController;
        
        private void Start()
        {
            var go = gameObject;
            movementController = new EnemyMovementController(go);
            stateHandler = new EnemyStateHandler(go, target, movementController);
        }

        private void Update()
        {
            stateHandler.Update();
            movementController.Update();
        }
    }
}