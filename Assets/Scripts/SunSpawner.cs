using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour{

    [Header ("Setup")]

    public GameObject coinPrefab;

    [Header ("Game Values")]

    private float timer = 5f;

    public float spawnDelay = 10f;

    public float minSpawnRange = 1f;

    public float maxSpawnRange = 10f;

    void Start(){

        timer = spawnDelay;
        
    }

    void Update(){

        timer -= Time.deltaTime;

        if(timer <= 0f){

            SpawnCoin();

        }
        
    }

    public void SpawnCoin(){

        timer = spawnDelay;

        GameObject sunInstance = Instantiate(coinPrefab, transform);

        sunInstance.transform.localPosition = new Vector3(Random.Range(minSpawnRange, maxSpawnRange), 300f, 0f);

    }

}
