using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
[System.Serializable]

public class Wave{

    public int SpawnAmount { get; set; }
    public int SpawnDelay { get; set; }

    public Wave(){

        this.SpawnAmount = 0;
        this.SpawnDelay = 0;

    }

    public Wave(int spawnAmount, int spawnDelay) : this() {

        this.SpawnAmount = spawnAmount;
        this.SpawnDelay = spawnDelay;

    }

}

public class WaveManager : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject newWaveMessagePrefab;
    public Transform newWaveMessageParent;
    public float waveDelay;

    private Wave[] level1 = new Wave[5];
    private Wave[] level2;
    private Wave[] level3;
    private Wave[] level4;
    private Wave[] level5;
    private Wave[] level6;
    private Wave[] level7;
    private Wave[] level8;
    private Wave[] level9;
    private Wave[] level10;

    private List<Wave[]> levels = new List<Wave[]>();

    private Wave currentWave;
    private int currentWaveNumber;
    private int levelIndex;
    private bool canSpawn = true;
    private bool a = false;
    private float nextSpawnTime;
    private float nextWaveTime;

    private void InitializeWaves(){

        level1[0] = new Wave(2, 3);
        level1[1] = new Wave(3, 5);
        level1[2] = new Wave(3, 5);
        level1[3] = new Wave(3, 5);
        level1[4] = new Wave(5, 3);

        levels.Add(level1);
        levels.Add(level2);
        levels.Add(level3);
        levels.Add(level4);
        levels.Add(level5);
        levels.Add(level6);
        levels.Add(level7);
        levels.Add(level8);
        levels.Add(level9);
        levels.Add(level10);

    }

    private void Start(){

        levelIndex = Convert.ToInt32(FindObjectOfType<LevelIndexManager>().levelIndex);

        InitializeWaves();

    }

    private void Update(){

        currentWave = levels[levelIndex - 1][currentWaveNumber];

        SpawnWave();

        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Ghoul");

        if (a && totalEnemies.Length == 0){

            nextWaveTime = Time.time + waveDelay;

            a = false;

        }

        if (totalEnemies.Length == 0 && !canSpawn && nextWaveTime < Time.time && !a){

            if ((currentWaveNumber + 1) != levels[levelIndex - 1].Length){

                SpawnNextWave();

                DisplayNewWaveMessage(levels[levelIndex -1][currentWaveNumber].SpawnAmount);

            } else {

                FindObjectOfType<GameManager>().FinishLevel(levelIndex);

            }

        }

    }

    private void SpawnNextWave(){

        currentWaveNumber++;
        canSpawn = true;

    }

    private void SpawnWave(){

        if (canSpawn && nextSpawnTime < Time.time){

            SpawnEnemy();

            currentWave.SpawnAmount--;

            nextSpawnTime = Time.time + currentWave.SpawnDelay;

            if (currentWave.SpawnAmount == 0){

                canSpawn = false;

                a = true;

            }

        }

    }

    private void SpawnEnemy(){

        var rd = new System.Random();

        int rand = rd.Next(-1, 4);

        float x = 0f;
        const float y = 0.5f;
        const float z = 11.25f;

        // Translate rand to x position
        for (int j = 0; j <= rand; j++) x += 1.25f;

        Vector3 spawnPosition = new Vector3(x, y, z);

        GameObject newEnemy = Instantiate(enemyPrefab);

        newEnemy.transform.position = spawnPosition;

    }

    public void DisplayNewWaveMessage(int numOfEnemies){

        GameObject message = Instantiate(newWaveMessagePrefab, newWaveMessageParent);

        message.GetComponent<Text>().text += $"{numOfEnemies} enemies";

        Destroy(message, 4f);

    }

}
