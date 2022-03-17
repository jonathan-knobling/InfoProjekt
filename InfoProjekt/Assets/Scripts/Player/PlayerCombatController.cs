using System;
using Enemies;
using IO;
using UnityEngine;
using Util.EventArgs;

namespace Player
{
    public class PlayerCombatController: MonoBehaviour
    {
        public static PlayerCombatController Instance;
        
        [SerializeField] private Animator animator;
        [SerializeField] private InputChannelSO inputChannel;
        [SerializeField] private Transform camTransform;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        public event EventHandler<StringEventArgs> OnEnemyKilled;
        private Stats stats;
        private static readonly int AnimatorAttack = Animator.StringToHash("attack");

        private void Start()
        {
            //player und enemy layers ignoren collision
            Physics2D.IgnoreLayerCollision(7,8);
            //enemies untereinander ignoren collision
            Physics2D.IgnoreLayerCollision(7,7);
            stats = GetComponent<Stats>();
            inputChannel.HitButtonPressed += OnHitButtonPressed;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void OnHitButtonPressed()
        {
            Vector2 mousePos = Input.mousePosition;
            if((mousePos.x/240 - 4 > transform.position.x - camTransform.position.x && Math.Abs(Mathf.Sign(transform.localScale.x) - (-1)) > 0.01f) || (mousePos.x/240 - 4 < transform.position.x - camTransform.position.x && Math.Abs(Mathf.Sign(transform.localScale.x) - 1) > 0.01f))
            {// wenn die maus rechts vom player is und der player nich nach rechts zeigt (x scale = negativ) || und anders rum       (240 sind die PPU) (4 sind die units vom rand links der cam bis zur mitte der cam)
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
            animator.SetTrigger(AnimatorAttack);
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyStats>().Hit(stats.AttackDamage);
                if(enemy.GetComponent<EnemyStats>().IsDead)
                {
                    stats.AddXp(enemy.GetComponent<EnemyStats>());
                    //event on enemy killed wird invoked und der name als eventarg gepassed
                    OnEnemyKilled?.Invoke(this, new StringEventArgs(enemy.GetComponent<EnemyStats>().enemyID));
                }
                stats.AddStrengthXp(stats.AttackDamage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
