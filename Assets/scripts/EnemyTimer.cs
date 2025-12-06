using UnityEngine;

public class EnemyTimer : MonoBehaviour
{
    private float startTime;
    public float ElapsedTime { get; private set; }

    
    void Start()
    {
        startTime = Time.time; // begint zodra het object gespawned is
        ElapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ElapsedTime = Time.time - startTime;
    }

    // om op te halen vanuit een ander script
    public float GetElapsedTime()
    {
        return ElapsedTime;
    }
}
