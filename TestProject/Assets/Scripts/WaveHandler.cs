using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class WaveHandler : MonoBehaviour
{

    public AnimationCurve EnemiesPerRound;
    public float spawnRate;
    public float maxSpawn;

    public WaveEnemyStats[] enemies;

    public Transform[] spawnPositions;

    private float lastSpawnTime;

    private int currentWave = 0;
    private float currentSpawn = 0;

    private int waveMaxEnemiesSpawn;
    private int waveCurrentEnemiesSpawned;

    private bool waveActive;

    public event EventHandler<WaveEventArgs> OnWaveEnded;
    public event EventHandler<WaveEventArgs> OnWaveStarted;

    private void Start()
    {
        AdvanceToNextWave();
    }
    private void Update()
    {
        if (Time.time >= lastSpawnTime + spawnRate)
        {
            if (currentSpawn < maxSpawn && waveCurrentEnemiesSpawned < waveMaxEnemiesSpawn && waveActive)
                Spawn();
        }
    }
    public void Spawn()
    {
        GameObject tem_Enemy = Instantiate(enemies[0].Enemy, GetRandomSpawnPosition().position, Quaternion.identity);
        AttributeHolder holder = tem_Enemy.GetComponent<AttributeHolder>();

        if (holder)
        {
            for (int i = 0; i < enemies[0].attributes.Length; i++)
            {
                AttributeName aName = enemies[0].attributes[i].attribute;
                AnimationCurve statCurve = enemies[0].attributes[i].curve;
                float curveValue = statCurve.Evaluate(currentWave);

                if (curveValue >= holder.GetAttribute(aName).clampValues.maximum)
                    holder.GetAttribute(aName).clampValues.maximum = curveValue;

                holder.GetAttribute(aName).Value = curveValue;

                Debug.Log(aName);
            }
        }

        tem_Enemy.GetComponent<HealthComponent>().OnHealthRunOut += DecreaseSpawnCount;
        currentSpawn++;
        waveCurrentEnemiesSpawned++;
        lastSpawnTime = Time.time;
    }

    private void DecreaseSpawnCount(object sender, System.EventArgs e)
    {
        currentSpawn--;
        if (currentSpawn == 0 && waveCurrentEnemiesSpawned >= waveMaxEnemiesSpawn)
        {
            EndWave();
        }
    }

    private Transform GetRandomSpawnPosition()
    {
        int randomNumber = UnityEngine.Random.Range(0, spawnPositions.Length);

        return spawnPositions[randomNumber];
    }
    private void StartWave()
    {
        waveCurrentEnemiesSpawned = 0;
        waveMaxEnemiesSpawn = (int)EnemiesPerRound.Evaluate(currentWave);
        waveActive = true;
        OnWaveStarted?.Invoke(this, new WaveEventArgs { wave = currentWave });
    }
    public void AdvanceToNextWave()
    {
        currentWave++;
        StartWave();
    }
    public void EndWave()
    {
        waveActive = false;     
        OnWaveEnded?.Invoke(this , new WaveEventArgs {wave= currentWave });
        StartCoroutine(WaitForNextWave(5));
    }

    IEnumerator WaitForNextWave(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        AdvanceToNextWave();
    }
    public int GetCurrentWave()
    {
        return currentWave;
    }
}

public class WaveEventArgs : EventArgs
{
    public int wave;
}
[System.Serializable]public class WaveEnemyStats
{
    public GameObject Enemy;
    public AttributeCurve [] attributes;
}

[System.Serializable]public class AttributeCurve
{
   public AttributeName attribute;
   public AnimationCurve curve;
}
