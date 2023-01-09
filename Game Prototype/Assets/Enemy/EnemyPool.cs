using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    [Tooltip("Spawn Timer between enemies")]
    private float spawnWait = 1f;
    private float waveWait = 2f;
    private int maxEnemies = 6;
    private int enemyCountNow = 0;
    private int wave = 1;
    bool spawningWave = true;
    public Text waveTxt;
    private void Start() {
        waveTxt.text = "Wave: " + wave;
        StartCoroutine(SpawnEnemyWave(maxEnemies));
    }
    private void Update() {
        enemyCountNow = FindObjectsOfType<Enemy>().Length;
        if(enemyCountNow == 0 && !spawningWave) {
            wave++;
            maxEnemies++;
            StartCoroutine(SpawnEnemyWave(maxEnemies));
            waveTxt.text = "Wave: " + wave;
        }
    }
    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        yield return new WaitForSeconds(waveWait); //We wait here to pause between wave spawning
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, transform);
            yield return new WaitForSeconds(spawnWait); //We wait here to give a bit of time between each enemy spawn
        }
        spawningWave = false;
    }
}
