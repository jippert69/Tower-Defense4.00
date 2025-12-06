using UnityEngine;

public class TorenKoppen : MonoBehaviour
{
    public GameObject torenPrefab;

    public void OnClick()
    {
        TorenManager manager = Object.FindFirstObjectByType<TorenManager>();//zoek de TorenManager in de scene
        manager.SelectTower(torenPrefab);//roep de SelectTower methode aan in TowerManager
    }
}
