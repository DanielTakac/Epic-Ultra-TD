using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour{

    [Header("Setup")]

    public GameObject minigunTurretPrefab;

    public GameObject hitEffectPrefab;

    public GameObject trailEffectPrefab;

    private GameObject trail;

    private GameObject[] enemies;

    private SoundManager soundManager;

    private float distance;

    public LayerMask ghoulLayer;

    [Header("Game Values")]

    public Vector3 spawnOffset;

    public float hitRadius = 0.5f;

    public float speed = 10f;

    private int damage = 0;

    private bool canMove = true;

    public float enemyScanFrequency = 0.2f;

    void Start(){

        //trail = Instantiate(trailEffectPrefab);

        //trail.transform.position = transform.position;

        damage = minigunTurretPrefab.GetComponent<MinigunTurret>().damage;

        soundManager = FindObjectOfType<SoundManager>();

        //soundManager.MinigunSpawn();

        Invoke("Destroy", 10f);

        InvokeRepeating("SlowUpdate", 0.2f, enemyScanFrequency);

    }

    void Update(){

        if (canMove){

            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

            //trail.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

        }

        //Old Method

        /*Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), new Vector3(0f, 0f, hitRadius), Color.red);

        Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), new Vector3(0f, 0f, hitRadius));

        if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius, ghoulLayer)){

            if (hasHit) { return; }

            if (hit.transform.gameObject.tag == "Ghoul"){

                hasHit = true;

                Hit(hit.transform.gameObject);

            }

        }*/

        //New Method

        if(enemies == null) { return; }

        for (int i = 0; i < enemies.Length; i++){

            if(enemies[i] != null){

                if(enemies[i].transform.position.x == transform.position.x){

                    distance = enemies[i].transform.position.z - transform.position.z;

                    if(distance <= hitRadius){

                        enemies[i].GetComponent<Ghoul>().TakeDamage(damage);

                        Destroy(gameObject);

                    }

                }

            }

        }

    }

    private void SlowUpdate(){

        enemies = GameObject.FindGameObjectsWithTag("Ghoul");

    }

    private void Hit(GameObject enemy){

        //soundManager.MinigunExplosion();

        enemy.GetComponent<Ghoul>().TakeDamage(damage);

        GameObject effect = Instantiate(hitEffectPrefab);

        effect.transform.position = transform.position + spawnOffset;

        Destroy(effect, 5f);

        Destroy(gameObject);

    }

    private void Destroy(){

        Destroy(gameObject);

        //Destroy(flame);

    }

}
