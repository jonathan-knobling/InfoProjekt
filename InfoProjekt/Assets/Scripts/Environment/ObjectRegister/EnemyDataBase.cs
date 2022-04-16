using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Environment.test
{
    public class EnemyDataBase: ScriptableObject
    {
        [SerializeField] private List<GameObject> enemyList;

        private Dictionary<string, GameObject> EnemyList =>
            enemyList.ToDictionary(enemy => enemy.name);

        public GameObject GetEnemy(string enemyName)
        {
            return EnemyList[enemyName];
        }
    }
}