using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private Transform viewPoint;
    [SerializeField] private float viewRadius = 5;
    private GameObject target;
    private Enemy stats;
    private Vector3 startingPosition;

    EnemyState state;
    EnemyRoamingState roamingState;
    EnemyChasingState chasingState;
    

    private void Awake()
    {
        roamingState = new EnemyRoamingState();
        chasingState = new EnemyChasingState();
        state = roamingState;
    }

    void Start()
    {
        startingPosition = transform.position;
        stats = GetComponent<Enemy>();
    }

    void Update()
    {
        state.Update(this, stats);
    }

    public Collider2D checkView()
    {
        Collider2D collider = Physics2D.OverlapCircle(viewPoint.position, viewRadius, targetLayer);
        if(collider == null)
        {
            return null;
        }
        if((collider.transform.position.x - transform.position.x) * transform.localScale.x < 0)
        {
            return collider;
        }
        return null;
    }

    public void changeState()
    {

    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }

    public Vector3 getStartingPosition()
    {
        return startingPosition;
    }
}
