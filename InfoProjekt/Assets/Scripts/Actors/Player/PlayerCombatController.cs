using System.Diagnostics.Tracing;
using Actors.Enemies;
using Actors.Player.Stats;
using Tech;
using Unity.Mathematics;
using UnityEngine;

namespace Actors.Player
{
    public class PlayerCombatController: MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private EventChannelSO eventChannel;
        [SerializeField] private Camera cam;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        private PlayerStats stats;
        
        //cached properties
        private static readonly int CPAttack = Animator.StringToHash("attack");
        private static readonly int CPAttackDirX = Animator.StringToHash("att_dir_x");
        private static readonly int CPAttackDirY = Animator.StringToHash("att_dir_y");

        private void Start()
        {
            stats = GetComponent<PlayerStats>();
            eventChannel.InputChannel.OnHitButtonPressed += OnHitButtonPressed;
        }

        private void OnHitButtonPressed()
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 playerPos = cam.WorldToScreenPoint(transform.position);

            Vector2 hitDir = math.sign((mousePos - playerPos).normalized);

            animator.SetFloat(CPAttackDirX, hitDir.x);
            animator.SetFloat(CPAttackDirY, hitDir.y);
            animator.SetTrigger(CPAttack);
            
            Attack();
        }

        private void Attack()
        {
            //get all enemies in aoe
            var colliders = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayers);


            //deal damage to enemies
            foreach(Collider2D enemy in colliders)
            {
                float dealtDamage = enemy.GetComponent<EnemyStats>().DealDamage(stats.AttackDamage);
                if(enemy.GetComponent<EnemyStats>().IsDead)
                {
                    stats.AddXP(enemy.GetComponent<EnemyStats>());
                    eventChannel.PlayerChannel.EnemyKilled(enemy.GetComponent<EnemyStats>().enemyID);
                }
                stats.XPManager.AddDealtDamage(dealtDamage);
            }
        }
    }
}
