using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Actors.Enemies
{
    public class EnemyMovementController
    {
        private readonly GameObject enemy;
        private readonly Animator animator;
        private readonly Rigidbody2D rb;
        private readonly EnemyStats stats;

        private readonly NavMeshAgent agent;

        public bool TargetReached => !agent.pathPending
                                     && agent.remainingDistance <= agent.stoppingDistance
                                     && !agent.hasPath || agent.velocity.sqrMagnitude == 0f;

        //private static readonly int Speed = Animator.StringToHash("speed");
        private bool FacingRight => Math.Abs(Mathf.Sign(enemy.transform.localScale.x) - 1) < 0.01f;

        public EnemyMovementController(GameObject enemy)
        {
            this.enemy = enemy;
            rb = enemy.GetComponent<Rigidbody2D>();
            //animator = enemy.GetComponent<Animator>();
            stats = enemy.GetComponent<EnemyStats>();
            
            agent = enemy.GetComponent<NavMeshAgent>();
            agent.updateRotation = false;
            agent.updateUpAxis = false;
        }

        public void Update()
        {
            if(rb.velocity.x > 0 && !FacingRight) Flip();
            //animator.SetFloat(Speed, Math.Abs(rb.velocity.magnitude));
        }

        public void Move(Vector2 destination)
        {
            agent.SetDestination(destination);
        }

        private void Flip()
        {
            var transform1 = enemy.transform;
            Vector3 scale = transform1.localScale;
            scale.x *= -1;
            transform1.localScale = scale;
        }

        public void MoveToRandomPosition(float walkRadius)
        {
            //Get Random Direction
            var randomDirection = Random.insideUnitCircle.normalized * walkRadius;
            //Get a valid Navmesh Position in this direction
            NavMesh.SamplePosition(randomDirection, out var hit, walkRadius, 1);
            //Move to the Navmesh Position
            Move(hit.position);
        }
    }
}
