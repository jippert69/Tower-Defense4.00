using UnityEngine;
using System.Collections.Generic;

public class TowerShoot : MonoBehaviour
{
      public float ShootRadius = 10f;
    private List<GameObject> TargetList = new List<GameObject>();

    void Update()
    {
        ScanForTargets();

        if (TargetList.Count > 0)
        {
            // Debug ray naar het eerste doelwit
            Debug.DrawRay(transform.position, 
                TargetList[0].transform.position - transform.position, 
                Color.red);
        }
    }

    // Zoekt elke frame naar doelen
    void ScanForTargets()
    {
        TargetList.Clear(); // lijst leegmaken

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, ShootRadius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                TargetList.Add(hitCollider.gameObject);

                // Veilig checken op EnemyTimer component
                EnemyTimer timer = hitCollider.GetComponent<EnemyTimer>();

                if (timer != null)
                {
                    float t = timer.GetElapsedTime();
                    Debug.Log("Enemy in range: " + hitCollider.name + " time: " + t);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ShootRadius);
    }
}
