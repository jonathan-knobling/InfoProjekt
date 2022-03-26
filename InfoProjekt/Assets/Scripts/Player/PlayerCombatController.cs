using System;
using Enemies;
using IO;
using Player.Stats;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerStats))]
    public class PlayerCombatController: MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private InputChannelSO inputChannel;
        [SerializeField] private PlayerCombatChannelSO combatChannel;
        [SerializeField] private Transform camTransform;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        private PlayerStats stats;
        
        //cached properties
        private static readonly int CPAttack = Animator.StringToHash("attack");

        private void Start()
        {
            stats = GetComponent<PlayerStats>();
            inputChannel.OnHitButtonPressed += OnHitButtonPressed;
            combatChannel.AddPlayerCombatController(this);
        }

        private void OnHitButtonPressed()
        {
            Debug.Log("Attack");
            Vector2 mousePos = Input.mousePosition;
            // wenn die maus rechts vom player is und der player nich nach rechts zeigt (x scale = negativ) || und anders rum       (240 sind die PPU) (4 sind die units vom rand links der cam bis zur mitte der cam)
            if((mousePos.x/240 - 4 > transform.position.x - camTransform.position.x && Math.Abs(Mathf.Sign(transform.localScale.x) - (-1)) > 0.01f) || (mousePos.x/240 - 4 < transform.position.x - camTransform.position.x && Math.Abs(Mathf.Sign(transform.localScale.x) - 1) > 0.01f))
            {
                var transformers = transform;
                Vector3 scale = transformers.localScale;
                scale.x *= -1;
                transformers.localScale = scale;
            }
            //Debug.Log(mousePos.x / 240 + "  |  " + (transform.position.x - camTransform.position.x) + "  |  " + transform.position.x + "," + camTransform.position.x);
            Attack();
        }

        private void Attack()
        {
            animator.SetTrigger(CPAttack);
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
            foreach(Collider2D enemy in hitEnemies)
            {
                float dealtDamage = enemy.GetComponent<EnemyStats>().Hit(stats.AttackDamage);
                if(enemy.GetComponent<EnemyStats>().IsDead)
                {
                    stats.AddXP(enemy.GetComponent<EnemyStats>());
                    combatChannel.EnemyKilled(enemy.GetComponent<EnemyStats>().enemyID);
                }
                stats.XPManager.AddDealtDamage(dealtDamage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
