using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemySpawn;
    Vector3 spawnPoint;

    public float spawnRate = 3.0f;
    public float nextSpawn = 0.0f;
    public int enemiesSpawned;
    public float enemySpawnx;

    public float timer = 3.0f;

    public int levelMax = 4;
    public static bool enemyKilled;

    void Start()
    {

        enemySpawnx = enemySpawn.transform.position.x;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (levelMax >= enemiesSpawned && timer <= 0)
        {
            Debug.Log(enemiesSpawned);
            spawnEnemy();
            timer = 3;
            Debug.Log(enemiesSpawned);
        }

        if (enemyKilled == true)
        {
            spawnEnemy();
            enemyKilled = false;
            levelMax += 1;
            enemiesSpawned--;
        }
    }

    public void spawnEnemy()
    {
        spawnPoint = new Vector3(enemySpawnx, transform.position.y, 0);
        Instantiate(enemy, spawnPoint, Quaternion.identity);
        enemiesSpawned++;

    }
}
