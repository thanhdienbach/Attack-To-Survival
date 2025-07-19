using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{

    [Header("Spawn wild waves variable")]
    [SerializeField] int maxWave;
    [SerializeField] int currentWave = 1;
    [SerializeField] float spawnTimeStepOffset = 5;

    [Header("Spawn wild varriable")]
    [SerializeField] Dictionary<GameObject, int> spawnWildDictionary = new Dictionary<GameObject, int>();
    [SerializeField] List<SpawnWildConfig> spawnWildConfigs = new List<SpawnWildConfig>();
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] List<int> enemyCounts;
    [SerializeField] float spawnDeley = 0.2f;
    [SerializeField] float spawnRadius = 10f;
    [SerializeField] Transform[] spawnPositions;
    
    
    public void Init()
    {
        spawnPositions = GetComponentsInChildren<Transform>();
        maxWave = spawnWildConfigs.Count;
    }

    public void SpawnWild()
    {
        StartCoroutine(SpawnWildCoroutine());
    }
    public IEnumerator SpawnWildCoroutine()
    {
        while (currentWave <= maxWave)
        {
            SpawnEnemyInWave(currentWave);
            yield return new WaitForSeconds(spawnTimeStepOffset * currentWave);
            currentWave++;
        }
    }

    void SpawnEnemyInWave(int _wave)
    {
        CreatSpawnWildDictionary(_wave);
        StartCoroutine(SpawnWave());
    }
    void CreatSpawnWildDictionary(int _wave)
    {
        spawnWildDictionary.Clear();
        enemyPrefabs.Clear();
        enemyCounts.Clear();

        enemyPrefabs.AddRange(spawnWildConfigs[_wave - 1].wilds);
        enemyCounts.AddRange(spawnWildConfigs[_wave - 1].count);

        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            if (enemyPrefabs[i] != null && enemyCounts[i] > 0)
            {
                spawnWildDictionary[enemyPrefabs[i]] = enemyCounts[i];
            }
        }
    }

    IEnumerator SpawnWave()
    {
        foreach (var pair in spawnWildDictionary)
        {
            GameObject wildCreature = pair.Key;
            int count = pair.Value;

            for (int i = 0;i < count;i++)
            {
                yield return new WaitForSeconds(spawnDeley);
                SpawnEnemy(wildCreature);
            }
        }
    }
    void SpawnEnemy(GameObject _wildCreature)
    {
        Vector3 randomOffset = Random.insideUnitSphere * spawnRadius;
        randomOffset.y = 0;
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)].position + randomOffset;

        Instantiate(_wildCreature, spawnPosition, Quaternion.identity);
    }

}
