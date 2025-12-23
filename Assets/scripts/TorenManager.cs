using UnityEngine;
using System.Collections.Generic;

public class TorenManager : MonoBehaviour
{
    public static TorenManager Instance { get; private set; }// Singleton instance
    
    public List<BuildSpot> allSpots = new List<BuildSpot>();
    public GameObject selectedTower;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void SelectTower(GameObject towerPrefab)
    {
        selectedTower = towerPrefab;

        foreach (BuildSpot spot in allSpots)
        {
            if (!spot.isBezet)
            {
                spot.Highlight(true);
            }
        }
    }

    public void DeselectTower()
    {
        selectedTower = null;

        foreach (BuildSpot spot in allSpots)
        {
            spot.Highlight(false);
        }
    }
}
