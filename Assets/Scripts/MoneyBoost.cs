using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyBoost : TurretBoost {

    [Header("Setup")]

    public GameObject coinPrefab;

    private Transform coin1;
    private Transform coin2;
    private Transform coin3;
    private Transform coin4;

    private bool stage1 = false;
    private bool stage2 = false;
    private bool stage3 = false;

    [Header("Game Values")]

    public Vector3 coinSpawnOffset;

    public float rotateSpeed = 5f;
    public float orbitSpeed = 5f;

    public float speed = 1f;

    public int moneyToGenerate = 100;

    void Update(){

        if (stage1){

            coin1.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            coin2.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            coin3.position += new Vector3(0f, 0f, speed * Time.deltaTime);
            coin4.position += new Vector3(0f, 0f, -speed * Time.deltaTime);

            coin1.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin2.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin3.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin4.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        }

        if (stage2){

            coin1.RotateAround(transform.position, transform.up, orbitSpeed * Time.deltaTime);
            coin2.RotateAround(transform.position, transform.up, orbitSpeed * Time.deltaTime);
            coin3.RotateAround(transform.position, transform.up, orbitSpeed * Time.deltaTime);
            coin4.RotateAround(transform.position, transform.up, orbitSpeed * Time.deltaTime);

            coin1.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin2.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin3.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin4.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        }

        if (stage3){

            Vector3 direction1 = coin1.position - transform.position - coinSpawnOffset;
            direction1 = -direction1.normalized;
            coin1.transform.position += direction1 * Time.deltaTime * speed;

            Vector3 direction2 = coin2.position - transform.position - coinSpawnOffset;
            direction2 = -direction2.normalized;
            coin1.transform.position += direction2 * Time.deltaTime * speed;

            Vector3 direction3 = coin3.position - transform.position - coinSpawnOffset;
            direction3 = -direction3.normalized;
            coin1.transform.position += direction3 * Time.deltaTime * speed;

            Vector3 direction4 = coin4.position - transform.position - coinSpawnOffset;
            direction4 = -direction4.normalized;
            coin1.transform.position += direction4 * Time.deltaTime * speed;

            coin1.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin2.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin3.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
            coin4.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);

        }

    }

    public override void Activate(){

        if (activated) return;

        Destroy(GameObject.FindGameObjectWithTag("Coin"));

        gameObject.GetComponent<MoneyTower>().canShoot = false;

        activated = true;

        Stage1();

    }

    private void Stage1(){

        stage1 = true;

        coin1 = Instantiate(coinPrefab).transform;
        coin2 = Instantiate(coinPrefab).transform;
        coin3 = Instantiate(coinPrefab).transform;
        coin4 = Instantiate(coinPrefab).transform;

        coin1.transform.position = transform.position + coinSpawnOffset;
        coin2.transform.position = transform.position + coinSpawnOffset;
        coin3.transform.position = transform.position + coinSpawnOffset;
        coin4.transform.position = transform.position + coinSpawnOffset;

        Invoke("Stage2", 2f);

    }

    private void Stage2(){

        stage1 = false;
        stage2 = true;

        Invoke("Stage3", 1f);

    }

    private void Stage3(){

        stage2 = false;
        stage3 = true;

        Invoke("Stage4", 2f);

    }

    private void Stage4(){

        Destroy(coin1.gameObject);
        Destroy(coin2.gameObject);
        Destroy(coin3.gameObject);
        Destroy(coin4.gameObject);

        stage3 = false;
        activated = false;

        GameManager.money += moneyToGenerate;

        gameObject.GetComponent<MoneyTower>().canShoot = true;

    }

}
