using System.ComponentModel;
using UnityEngine;

namespace Enemies.EnemyAI
{
    public class EnemyAI : MonoBehaviour
    {

        [SerializeField] private LayerMask targetLayer;
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
        [Description("mindestabstand zum target")]
        public float MinTargetDistance => minTargetDistance;
        
        public float ViewRadius => viewRadius;
        public float RoamingRadius => roamingRadius;
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
            Debug.Log(state.name);
        }

        public Collider2D CheckView()
        {
            Collider2D overlapCircle = Physics2D.OverlapCircle(transform.position, ViewRadius, targetLayer);
            if(overlapCircle == null)
            {
                return null;
            }
            //Wenn der Player vor dem Enemy ist (enemy hat keine augen im hinterkopf) weiss nich ob ich des keepen will aber
            if((overlapCircle.transform.position.x - transform.position.x) * -transform.localScale.x < 0)
            {
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

        private void OnDrawGizmos()
        {
            //Gizmos.DrawWireSphere(startingPosition, roamingRadius);
            var position = transform.position;
            Gizmos.DrawWireSphere(position, viewRadius);
            //Gizmos.DrawWireSphere(position, hitRadius);
        }
    }
}
