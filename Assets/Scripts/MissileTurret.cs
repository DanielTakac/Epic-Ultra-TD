using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : MonoBehaviour{

    [Header("Setup")]

    private SoundManager SoundManager;

    public GameObject missilePrefab;

    public GameObject smokeEffect;

    public Vector3 missileSpawnOffSet;

    public bool canShoot = true;

    public LayerMask ghoulLayer;

    [Header("Game Values")]

    public int damage = 24;

    public float hitRadius = 10f;

    public float shootDelay = 2f;

    private float attackTimer = 0f;

    void Start(){

        attackTimer = shootDelay;

        SoundManager = FindObjectOfType<SoundManager>();

    }

    void Update(){

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius), Color.white);

        Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius));

        if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius, ghoulLayer)){

            if (hit.transform.gameObject.tag == "Ghoul" && canShoot){

                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0f){

                    attackTimer = shootDelay;

                    SpawnMissile();

                }

            }

        }

    }

    private void SpawnMissile(){

        SoundManager.MissileSpawn();

        GameObject missile = Instantiate(missilePrefab);

        missile.transform.position = transform.position + missileSpawnOffSet;

        smokeEffect.GetComponent<ParticleSystem>().Play();

    }

}
