using System;
using Enemies;
using UnityEngine;
using Util;

namespace Player
{
    public class PlayerCombatController: MonoBehaviour
    {
        public static PlayerCombatController Instance;
        
        [SerializeField] private Animator animator;
        [SerializeField] private Transform camTransform;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange = 0.5f;
        [SerializeField] private LayerMask enemyLayers;
        public event EventHandler<StringEventArgs> OnEnemyKilled;

        private Stats stats;

        private void Start()
        {
            stats = GetComponent<Stats>();
        }

        private void Awake()
        {
            Instance = this;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector2 mousePos = Input.mousePosition;
                if((mousePos.x/240 - 4 > transform.position.x - camTransform.position.x && Mathf.Sign(transform.localScale.x) != -1) || (mousePos.x/240 - 4 < transform.position.x - camTransform.position.x && Mathf.Sign(transform.localScale.x) != 1))
                {// wenn die maus rechts vom player is und der player nich nach rechts zeigt (x scale = negativ) || und anders rum       (240 sind die PPU) (4 sind die units vom rand links der cam bis zur mitte der cam)
                    Vector3 scale = transform.localScale;
                    scale.x *= -1;
                    transform.localScale = scale;
                }
                //Debug.Log(mousePos.x / 240 + "  |  " + (transform.position.x - camTransform.position.x) + "  |  " + transform.position.x + "," + camTransform.position.x);
                Attack();
            }
        }

        private void Attack()
        {
            animator.SetTrigger("attack");
        
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyStats>().Hit(stats.getAttDmg());
                if(enemy.GetComponent<EnemyStats>().IsDead())
                {
                    stats.addXP(enemy.GetComponent<EnemyStats>());
                    //event on enemy killed wird invoked und der name als eventarg gepassed
                    OnEnemyKilled?.Invoke(this, new StringEventArgs(enemy.GetComponent<EnemyStats>().enemyID));
                }
                stats.addStrengthXP(stats.getAttDmg());
            }
        }

        private void OnDrawGizmosSelected()
        {
            if (attackPoint == null) return;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}
