using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;

    private float timeBetweenSpawn;
    public float spawnTime;
    public float obstacleSpeed;

    private void Update()
    {
        timeBetweenSpawn += Time.deltaTime;

        if (timeBetweenSpawn >= spawnTime && spawnTime > 0)
        {
            Spawn();
            timeBetweenSpawn = 0;
        }

    }

    private void Spawn()
    {
        GameObject obstacle = obstacles[Random.Range(0, obstacles.Length)];

        GameObject spawnedObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);

        Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * obstacleSpeed;

    }
     
}
