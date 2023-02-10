using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public Cactus cactus;
    //Making a range of possibilities for when to spawn the next cactus
    public float currentSpawnRate, spawnRateMin, spawnRateMax;
    private float timeSinceLastSpawn;

    private void Awake()
    {
        GenerateSpawnRate();
    }

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= currentSpawnRate)
        {
            timeSinceLastSpawn = 0;
            GenerateSpawnRate();
            Instantiate(cactus, transform.position, Quaternion.identity);
        }
    }

    private void GenerateSpawnRate()
    {
        currentSpawnRate = Random.Range(spawnRateMin, spawnRateMax);
    }

}
