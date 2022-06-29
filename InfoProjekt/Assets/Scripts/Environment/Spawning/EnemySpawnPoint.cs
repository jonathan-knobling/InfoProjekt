using System;
using Environment.ObjectRegister;
using Tech;
using UnityEngine;
using Util;

namespace Environment.Spawning
{
    public class EnemySpawnPoint : MonoBehaviour
    {

        [SerializeField] private GameObject enemySpawnPrefab;
        [SerializeField] private EventChannelSO eventChannel;

        private Timer timer;
        private const float SpawnTime = 25f;

        private void Start()
        {
            timer = new Timer(SpawnTime);
        }

        private void Update()
        {
            timer.Update();

            if (timer.Elapsed && eventChannel.ObjectRegisterChannel.currentMobCap < EnemyRegister.Mobcap)
            {
                timer.Restart();
                var instance = Instantiate(enemySpawnPrefab, transform.position, transform.rotation);
                eventChannel.ObjectRegisterChannel.RequestRegisterEnemy(instance);
            }
        }
    }
}
