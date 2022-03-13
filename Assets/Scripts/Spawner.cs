using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{

    public GameObject enemyPrefab;

    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;
    public Transform E;

    public void SpawnEnemy(int row){

        if(row == 1){

            GameObject enemy = Instantiate(enemyPrefab, A.position, A.rotation);

            enemy.transform.position += new Vector3(0f, 0.5f, 0f);

            enemy.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        }

        if (row == 2){

            GameObject enemy = Instantiate(enemyPrefab, B.position, B.rotation);

            enemy.transform.position += new Vector3(0f, 0.5f, 0f);

            enemy.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        }

        if (row == 3){

            GameObject enemy = Instantiate(enemyPrefab, C.position, C.rotation);

            enemy.transform.position += new Vector3(0f, 0.5f, 0f);

            enemy.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        }

        if (row == 4){

            GameObject enemy = Instantiate(enemyPrefab, D.position, D.rotation);

            enemy.transform.position += new Vector3(0f, 0.5f, 0f);

            enemy.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        }

        if (row == 5){

            GameObject enemy = Instantiate(enemyPrefab, E.position, E.rotation);

            enemy.transform.position += new Vector3(0f, 0.5f, 0f);

            enemy.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);

        }

        //Error check
        if (row > 5 || row < 1){

            Debug.LogError("Ghoul spawn row out of range");

            return;

        }

    }

}
