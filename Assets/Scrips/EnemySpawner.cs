using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemySpawn;
    Vector3 spawnPoint;

    public float spawnRate = 10.0f;
    public float nextSpawn = 0.0f;  
    public float enemiesSpawned = 1.0f;
    public float enemySpawnx;

    public float timer = 3.0f;

    public int  levelMax = 3;
    public int enemiesKilled;

    void Start()
    {
        enemySpawnx = enemySpawn.transform.position.x;
    }

    void Update()
    {
        timer -= Time.deltaTime;

            if (levelMax >= enemiesSpawned && timer <= 0)
            {
                nextSpawn = Time.time + spawnRate;
                spawnPoint = new Vector3(enemySpawnx, transform.position.y, 0);
                Instantiate(enemy, spawnPoint, Quaternion.identity);
                enemiesSpawned++;
                enemiesKilled++;
                timer = 10.0f;
            }
        }
}
