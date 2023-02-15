using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour

#region old unused
//{
//    public GameObject enemyPrefab;
//    public float spawnMinTime = 1.0f;
//    public float spawnMaxTime = 3.0f;

//    private float spawnTimer;
//    private System.Random random;

//    void Start()
//    {
//        random = new System.Random();
//        spawnTimer = GetRandomSpawnTime();
//    }

//    void Update()
//    {
//        spawnTimer -= Time.deltaTime;

//        if (spawnTimer <= 0)
//        {
//            SpawnEnemy();
//            spawnTimer = GetRandomSpawnTime();
//        }
//    }

//    void SpawnEnemy()
//    {
//        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
//    }

//    float GetRandomSpawnTime()
//    {
//        return (float)random.NextDouble() * (spawnMaxTime - spawnMinTime) + spawnMinTime;
//    }
//}

#endregion
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float InitialSpawnIntervalMin = 1.0f;
    public float InitialSpawnIntervalMax= 5.0f;

    [SerializeField] int CarSequenceAmount = 1;
    [SerializeField] float CarSpeed = 5f;
    [SerializeField] float CarDelay = 10f;
    [SerializeField] float CarDelaySequence = 0f;
    [SerializeField] float CarMaxDistance = 38f;

    // internals
    float InitialSpawnInterval;
    float TimeUntillNextCar;
    int CarInSequence;
    private void Start()
    {
        InitialSpawnInterval = Random.Range(InitialSpawnIntervalMin, InitialSpawnIntervalMax);
        TimeUntillNextCar = InitialSpawnInterval;
    }

    private void Update()
    {
        if (0 > TimeUntillNextCar)
        {
            SpawnEnemies();
            CarInSequence++;
        }

        //Aplication of times based on Car Sequence
        if (CarSequenceAmount >= CarInSequence)
        {
            TimeUntillNextCar = CarDelay + CarDelaySequence;
            CarInSequence = 0;
        }
        else
        {
            TimeUntillNextCar = CarDelay;
        }
        
        TimeUntillNextCar -= Time.deltaTime;
        //Debug.Log(TimeUntillNextCar);
    }

    private void SpawnEnemies()
    {
        //Instantiation of the gameobject, saved a reference for later use
        GameObject InstantiatedCar = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation, transform);
        // Search for CarSript to then apply stats to it.
        CarScript carScript = InstantiatedCar.GetComponent<CarScript>();
        if (carScript == null)
        {
            Debug.LogWarning("This spawned car is missing a CarScript");
            return;
        }
        carScript.CarSpeed = CarSpeed;
        carScript.CarLifetime = CarMaxDistance / CarSpeed;
    }
}
