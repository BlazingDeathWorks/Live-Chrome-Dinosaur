using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusSpawner : MonoBehaviour
{
    public Cactus cactus, cactus1, cactus2;
    //Making a range of possibilities for when to spawn the next cactus
    public float currentSpawnRate, spawnRateMin, spawnRateMax;
    public float spawnRateMax1, spawnRateMax2;
    private float timeSinceLastSpawn;
    private float offset;

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
            Instantiate(cactus, transform.position + new Vector3(0, offset, 0), Quaternion.identity);
        }
    }

    private void GenerateSpawnRate()
    {
        if (cactus = cactus1)
        {
            spawnRateMax = spawnRateMax1;
        }
        else
        {
            spawnRateMax = spawnRateMax2;
        }

        currentSpawnRate = Random.Range(spawnRateMin, spawnRateMax);
        float type = Random.Range(1, 3);

        if (type == 1)
        {
            cactus = cactus1;
            offset = 0;
        }
        else
        {
            cactus = cactus2;
            offset = 0.5f;
        }
    }
}
