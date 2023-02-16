using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSpawner : MonoBehaviour
{
    public GameObject logPrefab;
    public Transform[] spawnPoints;
    public float spawnIntervalMin = 1.0f;
    public float spawnIntervalMax = 4.0f;

    [SerializeField] float logSpeed = 5f;
    [SerializeField] float logDelay = 10f;

    private void Start()
    {
        StartCoroutine(SpawnLogs());
    }

    private IEnumerator SpawnLogs()
    {
        while (true)
        {
            float spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];
            Instantiate(logPrefab, spawnPoint.position, spawnPoint.rotation, transform.parent);
        }
    }
}
