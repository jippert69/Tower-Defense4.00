using UnityEngine;

public class BuildSpot : MonoBehaviour
{
    public Material defaultMat;
    public Material highlightMat;
    public bool isBezet = false;

    private Renderer rend;

    void Start()
    {
        TorenManager manager = Object.FindFirstObjectByType<TorenManager>();//zoek de TorenManager in de scene
        manager.allSpots.Add(this);//voeg zichzelf toe aan de lijst in TorenManager
        rend = GetComponent<Renderer>();
        rend.material = defaultMat; //non highlighted van start
    }

    public void Highlight(bool on)
{
    if (isBezet)
    {
        rend.material = defaultMat;
        return;
    }

    rend.material = on ? highlightMat : defaultMat;
}

    public void Build(GameObject towerPrefab)
    {
        if (isBezet) return;
        Instantiate(towerPrefab, transform.position, Quaternion.identity);
        isBezet = true;
        Highlight(false);
    }

}
