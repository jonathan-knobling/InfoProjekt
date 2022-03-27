using UnityEngine;

namespace Environment.Actors
{
    public abstract class Actor: MonoBehaviour
    {
        [SerializeField] protected new string name;
        
        //getter
        public string Name => name;
    }
}