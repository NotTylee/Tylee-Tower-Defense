using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class WaveSpawner : MonoBehaviour
{


    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform enemyPrefab;

    public Transform spawnPoint;  

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public TextMeshProUGUI waveCountDownText;


    private int waveIndex = 0;

    

    void Update()
    {
        if(EnemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            SceneManager.LoadScene("Win");
           
            this.enabled = false;
            
        }


        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -=Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.0}", countdown);
    }

    IEnumerator SpawnWave()                                           
    {
        PlayerStats.Rounds++;
         
        Wave wave = waves[waveIndex];


        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
         
    } 

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }


}
