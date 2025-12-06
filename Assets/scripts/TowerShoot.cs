using UnityEngine;
using System.Collections.Generic;

public class TowerShoot : MonoBehaviour
{
     public float ShootRadius = 10f;
    private List<GameObject> TargetList = new List<GameObject>();
    private LineRenderer lineRenderer; // Nieuwe regel
     public Transform customStartPoint;

    void Start()
    {
        // Haal de bestaande Line Renderer op
        lineRenderer = GetComponent<LineRenderer>();
        
        // Configureer alleen als het nog niet is ingesteld in de Inspector
        if (lineRenderer != null)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.enabled = false;
        }
    }

    void Update()
    {
        ScanForTargets();

        if (TargetList.Count > 0)
        {
            // Toon lijn naar eerste doelwit
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, customStartPoint.position); // Start positie
            lineRenderer.SetPosition(1, TargetList[0].transform.position); // Eind positie
        }
        else
        {
            // Verberg lijn als er geen doelwit is
            lineRenderer.enabled = false;
        }
    }

    // Zoekt elke frame naar doelen
    void ScanForTargets()
    {
        TargetList.Clear();
    
    Collider[] hitColliders = Physics.OverlapSphere(transform.position, ShootRadius);
    
    // Tijdelijke lijst voor alle gevonden vijanden
    List<GameObject> unsortedEnemies = new List<GameObject>();
    
    foreach (var hitCollider in hitColliders)
    {
        if (hitCollider.CompareTag("Enemy"))
        {
            unsortedEnemies.Add(hitCollider.gameObject);
        }
    }
    
    // Sorteer op basis van voortgang (hoogste elapsedTime eerst)
    unsortedEnemies.Sort((a, b) => {
        float timeA = a.GetComponent<EnemyTimer>()?.GetElapsedTime() ?? 0f;
        float timeB = b.GetComponent<EnemyTimer>()?.GetElapsedTime() ?? 0f;
        return timeB.CompareTo(timeA); // Omgekeerd sorteren (hoogste eerst)
    });
    
    TargetList = unsortedEnemies;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, ShootRadius);
    }
}
