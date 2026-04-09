using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Enemy spawner settings options
    [SerializeField] private float spawnTime = 3f;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform treetransform;
    [SerializeField] private Transform[] spawnPoints; 

    private float currentSpawnTime;
    private bool isWorking;

    private void Start()
    {
        currentSpawnTime = 0f;
        isWorking = true;
    }

    private void Update()
    {
        // Spawning enemies
        if(isWorking)
        {
            currentSpawnTime += Time.deltaTime;
            if (currentSpawnTime >= spawnTime)
            {
                var enemy = Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
                enemy.movement.SetTarget(treetransform);
                currentSpawnTime = 0f;
            }
        }
        
    }

    public void turnOff()
    {
        isWorking = false;
    }
}
