using UnityEngine;

namespace Carlo.Scripts
{
    public class HoverMovement : MonoBehaviour
    {
        [SerializeField] private float extent = 1;
        [SerializeField] private float speed = 1;
        private Vector3 startingPosition;

        void Start()
        {
            startingPosition = transform.position;
        }
    
        void Update()
        {
            var position = transform.position;
            position = new Vector3(position.x, Mathf.Sin(Time.time * speed) * extent + startingPosition.y, position.z);
            transform.position = position;
        }
    }
}
