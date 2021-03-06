using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class TeslaBoost : TurretBoost {

    public GameObject linePrefab;

    private Ghoul[] enemies;

    public int damage = 1;

    public float boostLength = 5;

    public int frequency = 2;

    private bool stage1 = false;

    public GameObject coil1;
    public GameObject coil2;
    public GameObject coil3;
    public GameObject coil4;

    private int hitCycle = 0;

    void FixedUpdate(){

        if (stage1){

            if (hitCycle == frequency){

                hitCycle = 0;

                for (int i = 0; i < enemies.Length; i++){

                    if (enemies[i] != null){

                        enemies[i].TakeDamage(damage);

                    }

                }

            }

            hitCycle++;

        }

    }

    public override void Activate(){

        if (activated) return;

        gameObject.GetComponent<TeslaTurret>().canShoot = false;

        activated = true;

        Stage1();

    }

    private void Stage1(){

        stage1 = true;

        GameObject[] tile = GameObject.FindGameObjectsWithTag("TileTarget");

        GameObject[] tempEnemies = GameObject.FindGameObjectsWithTag("Ghoul");

        enemies = new Ghoul[tempEnemies.Length];

        Debug.Log(tile.Length);

        for (int i = 0; i < tile.Length; i++){

            int randCoil = Random.Range(1, 5);

            GameObject line = Instantiate(linePrefab);

            if (randCoil == 1) { line.GetComponent<LightningBoltScript>().StartObject = coil1; }
            if (randCoil == 2) { line.GetComponent<LightningBoltScript>().StartObject = coil2; }
            if (randCoil == 3) { line.GetComponent<LightningBoltScript>().StartObject = coil3; }
            if (randCoil == 4) { line.GetComponent<LightningBoltScript>().StartObject = coil4; }

            line.GetComponent<LightningBoltScript>().EndObject = tile[i];

        }

        for(int i = 0; i < enemies.Length; i++){

            enemies[i] = tempEnemies[i].GetComponent<Ghoul>();

        }

        Invoke("Stage2", boostLength);

    }

    private void Stage2(){

        stage1 = false;

        activated = false;

        gameObject.GetComponent<TeslaTurret>().canShoot = true;

        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");

        for (int i = 0; i < lines.Length; i++){

            if(lines[i] != null){

                Destroy(lines[i]);

            }

        }

    }

}
