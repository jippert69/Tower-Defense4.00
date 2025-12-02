using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;   // Prefab to spawn
    public Transform spawnPoint;       // Where to spawn (optional)
    private float waitTimer = 20;
    private float currentTime;

    public void StartSpawn()
    {
        StartCoroutine(SpawnPrefabs());

    }

    private void FixedUpdate()
    {
        currentTime -= Time.deltaTime;

        // When timer reaches 0 or below, reset it
        if (currentTime <= 0f)
        {
            currentTime = waitTimer;
            Debug.Log("Timer reached 0 and reset!");
        }
    }

    private IEnumerator SpawnPrefabs()
    {
        if (waitTimer >= 20)
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
}
