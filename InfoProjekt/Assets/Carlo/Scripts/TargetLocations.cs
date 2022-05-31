using System.Collections.Generic;
using Carlo.Way_points;
using UnityEngine;

namespace Carlo.Scripts
{
    [CreateAssetMenu(menuName = "World/Target location")]
    public class TargetLocations : ScriptableObject 
    {
        [SerializeField] private Vector2 location;
        [SerializeField] private Type locationType;
        

        public Vector2 Location => location;
        public Type LocationType => locationType;
        public enum Type
        {
            House,
            Booth,
        }
    }
}