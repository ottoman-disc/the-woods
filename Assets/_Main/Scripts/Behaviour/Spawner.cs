using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var spawnPos = transform.position + new Vector3(Random.Range(0,2), 0, Random.Range(0, 2));
        Instantiate(enemyPrefab, spawnPos, transform.rotation);
        Debug.Log("Spawned new ememy");
    }
}
