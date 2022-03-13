using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class WaveManager : MonoBehaviour{

    public GameObject enemyPrefab;
    public GameObject newWaveMessagePrefab;
    public Transform newWaveMessageParent;
    public Text levelIndexText;

    void Start() {

        int levelIndex = Convert.ToInt32(levelIndexText.text);

        var json = Resources.Load<TextAsset>("WaveInfo");

        var waveInfo = JsonConvert.DeserializeObject<WaveInfo2[]>(json.text);

    }

    public void SpawnEnemy(int amount = 1) {

        for (int i = 0; i < amount; i++) {

            var rd = new System.Random();

            int rand = rd.Next(1, 6);

            float x = 0f;

            // Translate rand to x position
            for (int j = 0; j <= rand; j++) x += 1.25f;

            Vector3 spawnPosition = new Vector3(x, 0.5f, 11.25f);

            GameObject newEnemy = Instantiate(enemyPrefab);

            newEnemy.transform.position = spawnPosition;

        }

        Debug.Log(amount + " enemies spawned!");

    }

    public class WaveInfo3 {

        public WaveInfo2[] WaveInfo2 { get; set; }

    }

    public class WaveInfo2 {

        public WaveInfo[] WaveInfo { get; set; }

    }

    public class WaveInfo {

        public int SpawnAmount { get; set; }
        public int SpawnDelay { get; set; }

    }

    public void NewWave(WaveInfo[] waveInfo) {

        DisplayNewWaveMessage();

        foreach (WaveInfo wave in waveInfo) {

            SpawnEnemy(wave.SpawnAmount);

            //Delay(wave.SpawnDelay);

        }

    }

    public void DisplayNewWaveMessage() {

        GameObject message = Instantiate(newWaveMessagePrefab, newWaveMessageParent);

        Destroy(message, 4f);

    }

}
