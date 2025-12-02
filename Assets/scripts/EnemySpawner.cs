using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // Prefab to spawn
    public Transform spawnPoint;       // Where to spawn (optional)

    public void StartSpawn()
    {
        StartCoroutine(SpawnPrefabs());
    }

    private IEnumerator SpawnPrefabs()
    {
        for (int i = 0; i < 10; i++)
        {
            // Spawn at spawnPoint if assigned, otherwise at this object's position
            Vector3 position = spawnPoint ? spawnPoint.position : transform.position;

            Instantiate(prefabToSpawn, position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
