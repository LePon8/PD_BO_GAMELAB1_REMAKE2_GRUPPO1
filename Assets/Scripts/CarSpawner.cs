using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
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
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnIntervalMin = 1.0f;
    public float spawnIntervalMax = 5.0f;

    [SerializeField] int CarSequenceAmount = 1;
    [SerializeField] float CarSpeed = 5f;
    [SerializeField] float CarDelay = 10f;
    [SerializeField] float CarDelaySequence = 0f;
    [SerializeField] float CarMaxDistance = 38f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
