using System.Collections.Generic;
using UnityEngine;

namespace Actors.Enemies.EnemyAITest
{
    public class EnemyTest: MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Camera cam;
        private Rigidbody2D rb;
        
        private static Vector2 _ul = (Vector2.up + Vector2.left).normalized;
        private static Vector2 _um = (Vector2.up).normalized;
        private static Vector2 _ur = (Vector2.up + Vector2.right).normalized;
        private static Vector2 _ml = (Vector2.left).normalized;
        private static Vector2 _mr = (Vector2.right).normalized;
        private static Vector2 _dl = (Vector2.down + Vector2.left).normalized;
        private static Vector2 _dm = (Vector2.down).normalized;
        private static Vector2 _dr = (Vector2.down + Vector2.right).normalized;

        private Dictionary<Vector2, float> dirWeigths;
        private Vector2[] directions;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            dirWeigths = new Dictionary<Vector2, float>(8);
            directions = new[] {_ul,_um,_ur,_ml,_mr,_dl,_dm,_dr};
        }

        private void Update()
        {
            GetWeights();
            
            
        }

        private void GetWeights()
        {
            foreach (var direction in directions)
            {
                float value = CalculateDirection(direction);

                if (value is not -1f)
                {
                    dirWeigths.TryAdd(direction, value);
                } 
                
                //Debug
                if (value is >= 0.99f or -1f)
                {
                    Debug.DrawRay(transform.position, direction, Color.green);
                    continue;
                }
                
                Debug.DrawRay(transform.position, direction * value, Color.red);
            }
        }

        private float CalculateDirection(Vector2 dir)
        {
            var result = Physics2D.Raycast(transform.position, dir);

            if (result.collider == null) return -1f;
            
            if (result.distance < 1f)
            {
                return result.distance;
            }
            
            return 1f;
        }
    }
}