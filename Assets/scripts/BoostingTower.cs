using UnityEngine;

public class BoostingTower : MonoBehaviour
{
    [SerializeField]
    private float boostModifier = 1.2f;


    void Start()
    {
        BoostNearbyTowers(boostModifier);
    }

    // functie kijjkt of er torens zijn
    void BoostNearbyTowers(float multiplier)
    { //[] = array
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 10f);
        // als torens zijn zijn ze IBoostable
        foreach (var hitCollider in hitColliders)
        {// roep BoostStats aan met boostModifier
            IBoostable boostableTower = hitCollider.GetComponent<IBoostable>();
            if (boostableTower != null)
            {
                boostableTower.Booststats(boostModifier);
            }

            //if(hit.enemyGameObject.GetComponent<IBoostable>() != null)
            //{
            //     hit.enemyGameObject.GetComponent<IBoostable>().BoostStats(boostModifier);
            //    
            //}
        }
    }
}
