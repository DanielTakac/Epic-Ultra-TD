using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTower : MonoBehaviour {

    [Header("Setup")]

    public GameObject coinPrefab;

    [Header("Game Values")]

    public Vector3 coinSpawnOffset;

    public int moneyToGenerate = 10;

    public float shootDelay = 2f;

    private float attackTimer = 0f;

    public bool canShoot = true;

    void Start(){

        attackTimer = shootDelay;

    }

    void Update(){

        if (canShoot){

            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f){

                attackTimer = shootDelay;

                GenerateMoney();

            }

        }

    }

    private void GenerateMoney(){

        GameManager.money += moneyToGenerate;

        GameObject coin = Instantiate(coinPrefab);

        coin.transform.position = transform.position + coinSpawnOffset;

    }

}
