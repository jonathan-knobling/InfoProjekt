using System.Collections.Generic;
using Carlo.Scripts;
using UnityEngine;

namespace Carlo.Way_points
{
    [CreateAssetMenu(menuName = "World/Target Database")]
    public class WayPointDatabase : ScriptableObject
    {
        //one list for each location type
        
        [SerializeField] private List<TargetLocations> houseTargetLocations;
        [SerializeField] private List<TargetLocations> boothTargetLocations;

        private TargetLocations GetRandomLocation(List<TargetLocations> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}