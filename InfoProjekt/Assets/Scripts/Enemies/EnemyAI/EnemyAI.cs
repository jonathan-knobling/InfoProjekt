using System.ComponentModel;
using UnityEngine;

namespace Enemies.EnemyAI
{
    public class EnemyAI : MonoBehaviour
    {

        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private Transform viewPoint;
        [SerializeField] private float viewRadius = 5;
        [SerializeField] private float roamingRadius = 20;
        [SerializeField] private float minTargetDistance = 0.3f;
        [SerializeField] private float hitRadius = 0.7f;
        private Animator animator;
        private EnemyStats stats;
        private Vector2 startingPosition;

        private EnemyState state;
        private EnemyRoamingState roamingState;
        private EnemyChasingState chasingState;

        //getter und setter
        public float ViewRadius => viewRadius;
        public float RoamingRadius => roamingRadius;
        [Description("mindestabstand zum target")]public float MinTargetDistance => minTargetDistance;
        public float HitRadius => hitRadius;
        public Animator Animator => animator;
        public EnemyStats Stats => stats;
        public GameObject Target { set; get; }
        public Vector2 StartingPosition => startingPosition;
        
    

        private void Awake()
        {
            roamingState = new EnemyRoamingState();
            chasingState = new EnemyChasingState();
            state = roamingState;
            state.EnterState(this);
        }

        void Start()
        {
            startingPosition = transform.position;
            stats = GetComponent<EnemyStats>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            state.Update(this);
        }

        public Collider2D CheckView()
        {
            Collider2D overlapCircle = Physics2D.OverlapCircle(viewPoint.position, ViewRadius, targetLayer);
            if(overlapCircle == null)
            {
                return null;
            }
            if((overlapCircle.transform.position.x - transform.position.x) * transform.localScale.x < 0)
            {
                Debug.Log("overlap");
                return overlapCircle;
            }
            return null;
        }

        public void SwitchState()
        {
            if (state == chasingState)
            {
                state = roamingState;
                state.EnterState(this);
            }
            else
            {
                state = chasingState;
                state.EnterState(this);
            }
            Debug.Log("Switch State");
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(startingPosition, roamingRadius);
            Gizmos.DrawWireSphere(transform.position, viewRadius);
            Gizmos.DrawWireSphere(transform.position, hitRadius);
            
        }
    }
}
