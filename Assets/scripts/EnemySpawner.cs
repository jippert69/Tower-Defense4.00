using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;      // Assign in Inspector
    public float interval = 0.5f;  // Spawn every 0.5 seconds

    void Start()
    {
        InvokeRepeating(nameof(SpawnPrefab), interval, interval);
    }

    void SpawnPrefab()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
