using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs = new List<WaveConfigSO>();
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    int loopAmount = 0;
     WaveConfigSO currentWave;

    void Start()
    {
        isLooping = true;
        StartCoroutine(SpawnEnemyWaves()); 
    }

    IEnumerator SpawnEnemyWaves()
    {

        do
        {
           
            loopAmount++;
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.getEnemyPrefab(i),
                     currentWave.GetStartingWaypoint().position
                     , Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawntime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }

        } while (isLooping == true);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}


