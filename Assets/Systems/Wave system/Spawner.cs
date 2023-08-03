using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.WaveSystem
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] Vector3 spawnArea;

        public GameObject SpawnCreature(GameObject creature){
            var spawnedCreature = ObjectPooling.InstantiateObject(creature, GetRandomSpawnPoint(), creature.transform.rotation);
            return spawnedCreature;
        }

        Vector3 GetRandomSpawnPoint(){
            float randomX = Random.Range(-spawnArea.x/2,spawnArea.x/2);
            float randomZ = Random.Range(-spawnArea.z/2,spawnArea.z/2);

            Vector3 randomPosition = transform.position + new Vector3(randomX, 0, randomZ);

            return randomPosition;

        }

        #if UNITY_EDITOR
        void OnDrawGizmosSelected()
        {
            //Red color with 50% of transparency
            Gizmos.color = new Color(255f, 0f, 0f, 0.5f);
            Gizmos.DrawCube(transform.position, spawnArea);
        }
        #endif

    }
}
