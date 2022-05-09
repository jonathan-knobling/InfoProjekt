using System.Runtime.CompilerServices;
using UnityEngine;

namespace Actors
{
    public class Projectile: MonoBehaviour
    {
        [SerializeField] private GameObject instantiateOnCollide;
        [SerializeField] private bool instantiateWithSameRotation;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            Destroy(gameObject);
            
            if (instantiateOnCollide.Equals(null)) return;

            var transform1 = transform;
            if (instantiateWithSameRotation)
            {
                Instantiate(instantiateOnCollide, transform1.position, transform1.rotation);
                return;
            }
            Instantiate(instantiateOnCollide, transform1.position, new Quaternion(0, 0, 0, 0));
        }
    }
}