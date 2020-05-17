using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OttomanDisc
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private float spawnDelay = 1f;

        [SerializeField]
        private int spawnCount = 5;

        [SerializeField]
        private Bat enemyPrefab;

        IEnumerator Start()
        {
            for (var i = 0; i < spawnCount; i++)
            {
                yield return new WaitForSeconds(spawnDelay);
                Spawn();
            }
        }

        private void Spawn()
        {
            var spawnPos = transform.position + new Vector3(Random.Range(0, 5), 0, Random.Range(0, 5));
            Instantiate(enemyPrefab, spawnPos, transform.rotation);
            Debug.Log("Spawned new ememy");
        }
    }
}
