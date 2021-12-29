using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Wavespawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private float timeBetweenWaves = 5f;

    private float countdown = 2f;
    private int waveindex = 0;

    [SerializeField] private Text waveCountDownText;
    private void Update()
    {
        if (countdown<= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }
    IEnumerator SpawnWave()
    {
        waveindex++;
        for (int i = 0; i < waveindex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
        
    } 
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);

    }
}
