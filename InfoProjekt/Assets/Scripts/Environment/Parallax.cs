using UnityEngine;

namespace Environment
{
    public class Parallax : MonoBehaviour
    {
        private Camera cam;
        private Vector3 startPosition;
        private float camStartX;
        private float CamTravel => cam.transform.position.x - camStartX;
        private float parallaxFactor;

        public void Start()
        {
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();
            
            var position = transform.position;
            startPosition = position;
            camStartX = cam.transform.position.x;
            float clipFar = cam.farClipPlane;
            parallaxFactor = -position.z / clipFar;
            if (parallaxFactor > clipFar)
                parallaxFactor = clipFar;
        }

        public void Update()
        {
            float newPosX = startPosition.x + CamTravel * parallaxFactor;
            var transform1 = transform;
            transform1.position = new Vector3(newPosX, transform1.position.y, startPosition.z);
        }
    
    }
}
