using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    
    private float timeBetweenSpawn;
    private float timeBetweenSpawn2;
    public float spawnTime = 3f;
    public float obstacleSpeed = 6f;

    public GameObject obstaculo;
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType(typeof(GameController)) as GameController;
    }

    private void Update()
    {
        
        if(!gameController.mode)
        {
            timeBetweenSpawn2 = 0;
            timeBetweenSpawn += Time.deltaTime;
            if (timeBetweenSpawn >= spawnTime && spawnTime > 0)
            {
                Spawn();
                timeBetweenSpawn = 0;
            }
        } else
        {
            timeBetweenSpawn = 0;
            timeBetweenSpawn2 += Time.deltaTime;
            if (timeBetweenSpawn2 >= spawnTime)
            {
                GameObject newObstaculo = Instantiate(obstaculo);
                newObstaculo.transform.position = transform.position + new Vector3(0, Random.Range(-3, 4), 0);
                Rigidbody2D rb = newObstaculo.GetComponent<Rigidbody2D>();
                rb.velocity = Vector2.left * obstacleSpeed;

                timeBetweenSpawn2 = 0;
            }
        }


    }

    private void Spawn()
    {
        int random = Random.Range(0, obstacles.Length);
        
        if (random == 4 || random == 5){
            // se a platafroma for chamada chama os obstaculos tbm
            // de forma analoga se os obstaculos forem chamados invoca a plataforma
            if (random == 4){
                GameObject obstacle1 = obstacles[5];
                GameObject spawnedObstacle1 = Instantiate(obstacle1, transform.position, Quaternion.identity);
                Rigidbody2D rb1 = spawnedObstacle1.GetComponent<Rigidbody2D>();
                rb1.velocity = Vector2.left * obstacleSpeed;
            }
            else{
                GameObject obstacle1 = obstacles[4];
                GameObject spawnedObstacle1 = Instantiate(obstacle1, transform.position, Quaternion.identity);
                Rigidbody2D rb1 = spawnedObstacle1.GetComponent<Rigidbody2D>();
                rb1.velocity = Vector2.left * obstacleSpeed;

            }
        }

        GameObject obstacle = obstacles[random];
        GameObject spawnedObstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
        Rigidbody2D rb = spawnedObstacle.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * obstacleSpeed;

    }
     
}
