using UnityEngine;
using System.Collections.Generic;

public class TorenManager : MonoBehaviour
{
    public List<BuildSpot> allSpots = new List<BuildSpot>();//lijst van alle bouwplekken
    public GameObject selectedTower;

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
