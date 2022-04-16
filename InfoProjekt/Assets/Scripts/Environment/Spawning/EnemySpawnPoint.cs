using System;
using Environment.ObjectRegister;
using UnityEngine;
using Util;

namespace Environment.Spawning
{
    public class EnemySpawnPoint : MonoBehaviour
    {

        [SerializeField] private GameObject enemySpawnPrefab;
        [SerializeField] private ObjectRegisterChannelSO objectRegister;

        private Timer timer;
        private const float SpawnTime = 25f;

        private void Start()
        {
            timer = new Timer(SpawnTime);
        }

        private void Update()
        {
            timer.Update();

            if (timer.Elapsed && objectRegister.currentMobCap < EnemyRegister.mobcap)
            {
                timer.Restart();
                var instance = Instantiate(enemySpawnPrefab, transform.position, transform.rotation);
                objectRegister.RequestRegisterEnemy(instance);
            }
        }
    }
}
