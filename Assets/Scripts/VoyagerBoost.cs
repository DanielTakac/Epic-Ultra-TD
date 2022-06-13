using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoyagerBoost : TurretBoost {

    [Header("Setup")]

    private GameObject[] laser;

    private GameObject[] currentEnemies;

    public GameObject laserPrefab;

    public GameObject lightPrefab;

    private int laserLength;

    private bool stage1 = false;

    [Header("Game Values")]

    public Vector3 laserSpawnOffSet;

    public float maxDistance;

    public float boostLength;

    public int damage = 1;

    public float hitRadius = 30f;

    private void FixedUpdate(){

        if (stage1 && currentEnemies != null){

            for (int i = 0; i < currentEnemies.Length; i++){

                if (currentEnemies[i] != null && currentEnemies[i].transform.position.x == transform.position.x){

                    currentEnemies[i].GetComponent<Ghoul>().TakeDamage(damage);

                }

            }

        }
        
    }

    private void SlowUpdate(){

        currentEnemies = GameObject.FindGameObjectsWithTag("Ghoul");

    }

    public override void Activate(){

        if (activated) return;

        activated = true;

        Stage1();

    }

    private void Stage1(){

        soundManager.LaserSpawn();

        laser = new GameObject[25];

        float spawnDistance = 0f;

        laserLength = 25;

        for (int i = 0; i < laser.Length; i++){

            laser[i] = Instantiate(laserPrefab);

            laser[i].transform.position = transform.position + laserSpawnOffSet + new Vector3(0f, 0f, spawnDistance);

            if (laser[i].transform.position.z > maxDistance){

                laserLength--;

                Destroy(laser[i]);

            }

            spawnDistance += 0.5f;

        }

        stage1 = true;

        Invoke("Stage2", boostLength);

    }

    private void Stage2(){

        activated = false;

        for (int i = 0; i < laserLength; i++){

            Destroy(laser[i]);

        }

    }

}
