using UnityEngine;

namespace Assets.Carlo.Scripts
{
    public class HoverMovement : MonoBehaviour
    {
        [SerializeField] private float extent = 1;
        [SerializeField] private float speed = 1;
        private Vector3 position;

        void Start()
        {
            position = transform.position;
        }
    
        void Update()
        {
            transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * speed) * extent + position.y, transform.position.z);
        }
    }
}
