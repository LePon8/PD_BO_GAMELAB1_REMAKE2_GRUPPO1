using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs;
    public float spawnInterval = 2.0f;
    public float spawnDistanceFromPlayer = 0.0f;

    private float spawnTimer = 0.0f;

    
    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0.0f;

            // Generate a random spawn point along the length of the strip
            float spawnPoint = transform.position.x + Random.Range(0.0f, GetComponent<SpriteRenderer>().bounds.size.x);

            // Spawn the obstacle
            Vector3 spawnPosition = new Vector3(spawnPoint, transform.position.y, transform.position.z + spawnDistanceFromPlayer);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Count);
            GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, Quaternion.identity);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            UIManager.Instance.GameOver();
        }
    }
}
