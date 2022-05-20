using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunTurret : MonoBehaviour{

    [Header("Setup")]

    private SoundManager SoundManager;

    public GameObject bulletPrefab;

    public GameObject muzzleFlash;

    public Transform barrel;

    public bool canShoot = true;

    public LayerMask ghoulLayer;

    [Header("Game Values")]

    public int damage = 2;

    public float hitRadius = 10f;

    public float shootDelay = 0.2f;

    public float boostedShootDelay = 0.05f;

    private float attackTimer = 0f;

    public bool isBoosted = false;

    void Start(){

        attackTimer = shootDelay;

        SoundManager = FindObjectOfType<SoundManager>();

    }

    void Update(){

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius), Color.white);

        Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, hitRadius));

        if (isBoosted && canShoot) {

            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0f) {

                attackTimer = boostedShootDelay;

                SpawnBullet();

            }

        } else if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius, ghoulLayer)) {

            if (hit.transform.gameObject.tag == "Ghoul" && canShoot) {

                attackTimer -= Time.deltaTime;

                if (attackTimer <= 0f) {

                    attackTimer = shootDelay;

                    SpawnBullet();

                }

            }

        }

    }

    private void SpawnBullet(){

        //SoundManager.BulletSpawn();

        GameObject bullet = Instantiate(bulletPrefab);

        bullet.transform.position = barrel.position;

        //muzzleFlash.GetComponent<ParticleSystem>().Play();

    }

}
