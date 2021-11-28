using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform [] spawnPositions;
    public GameObject enemy;

    public float spawnRate;
    private float lastSpawnTime;

    public float maxSpawn;
    private float currentSpawn = 0;




    private void Update()
    {
        if (Time.time >= lastSpawnTime + spawnRate)
        {
            if(currentSpawn  < maxSpawn)
            Spawn();
        }
    }
    public void Spawn()
    {
        GameObject tem_Enemy = Instantiate(enemy, GetRandomSpawnPosition().position, Quaternion.identity);
        tem_Enemy.GetComponent<HealthComponent>().OnHealthRunOut += DecreaseSpawnCount;
        currentSpawn++;
        lastSpawnTime = Time.time;
    }

    private void DecreaseSpawnCount(object sender, System.EventArgs e)
    {
        currentSpawn--;
    }

    private Transform GetRandomSpawnPosition()
    {
        int randomNumber = Random.Range(0 , spawnPositions.Length);

        return spawnPositions[randomNumber];
    }
}
