using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voyager : MonoBehaviour{

    [Header("Setup")]

    private SoundManager soundManager;

    public GameObject laserPrefab;

    public Vector3 laserSpawnOffSet;

    public bool canShoot = false;

    public LayerMask ghoulLayer;

    [Header("Game Values")]

    public int damage = 24;

    public float hitRadius = 10f;

    public float shootDelay = 2f;

    private float attackTimer = 0f;

    void Start(){

        attackTimer = shootDelay;

        soundManager = FindObjectOfType<SoundManager>();

    }

    void Update(){

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius), Color.white);

        Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius));

        //RaycastHit hit = Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius), LayerMask.NameToLayer("IgnoreTHis"));

        if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius, ghoulLayer)){

            if(hit.transform.gameObject.tag == "Ghoul"){

                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0f){

                    attackTimer = shootDelay;

                    SpawnLaser();
                    
                }

            }

        }

    }

    private void SpawnLaser(){

        soundManager.LaserSpawn();

        GameObject laser = Instantiate(laserPrefab);

        laser.transform.position = transform.position + laserSpawnOffSet;

    }

}
