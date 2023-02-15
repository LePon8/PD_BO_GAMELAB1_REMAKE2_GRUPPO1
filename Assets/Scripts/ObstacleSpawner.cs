using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    [SerializeField] Transform[] SpawnPoints;
    [Range(0f,1f)] public float SpawnChance = 0.2f;
    //public float spawnInterval = 2.0f;
    public float spawnDistanceFromPlayer = 0.0f;

    //private float spawnTimer = 0.0f;

    
    // Update is called once per frame
    void Start()
    {
        foreach (Transform spawnPoint in SpawnPoints)
        {
            float RNGroll = Random.Range(0f, 1f);

            if (RNGroll < SpawnChance)
            {
                int obstacleIndex = Random.Range(0, obstaclePrefabs.Length -1);
                Instantiate(obstaclePrefabs[obstacleIndex], spawnPoint.position, Quaternion.identity, transform);
            }
        }
        // Generate a random spawn point along the length of the strip
        //float spawnPoint = transform.position.x + Random.Range(0.0f, GetComponent<SpriteRenderer>().bounds.size.x);

        // Spawn the obstacle

    }

    private void OnDrawGizmosSelected()
    {
        foreach (Transform spawnPoint in SpawnPoints)
        {
            Gizmos.DrawWireCube(spawnPoint.position + (Vector3.up * 0.5f), Vector3.one);
        }
    }
}
