using UnityEngine;

namespace Environment
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform player;
        private Vector3 startPosition;
        private float camStartX;
        private float camTravel => cam.transform.position.x - camStartX;
        private float parallaxFactor;

        public void Start()
        {
            startPosition = transform.position;
            camStartX = cam.transform.position.x;
            float clipFar = cam.farClipPlane;
            parallaxFactor = -transform.position.z / clipFar;
            if (parallaxFactor > clipFar)
                parallaxFactor = clipFar;
        }

        public void Update()
        {
            float newPosX = startPosition.x + camTravel * parallaxFactor; 
            transform.position = new Vector3(newPosX, transform.position.y, startPosition.z);
        }
    
    }
}
