using UnityEngine;

namespace Enemies.EnemyAI
{
    public class EnemyAI : MonoBehaviour
    {

        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private Transform viewPoint;
        [SerializeField] public float viewRadius = 5;
        [SerializeField] public float roamingRadius = 20;
        public GameObject target { get; set; }
        private EnemyStats stats;
        public Vector2 startingPosition { get; set; }

        private EnemyState state;
        private EnemyRoamingState roamingState;
        private EnemyChasingState chasingState;
    

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
        }

        void Update()
        {
            state.Update(this);
        }

        public Collider2D CheckView()
        {
            Collider2D overlapCircle = Physics2D.OverlapCircle(viewPoint.position, viewRadius, targetLayer);
            if(overlapCircle == null)
            {
                return null;
            }
            if((overlapCircle.transform.position.x - transform.position.x) * transform.localScale.x < 0)
            {
                Debug.Log("overlap lloooooll");
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
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(startingPosition, roamingRadius);
        }
    }
}
