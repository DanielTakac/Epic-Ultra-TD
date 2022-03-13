using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour{

    [Header("Setup")]

    public GameObject missileTurretPrefab;

    public GameObject hitEffectPrefab;

    public GameObject flameEffectPrefab;

    private GameObject flame;

    private SoundManager soundManager;

    [Header("Game Values")]

    public Vector3 spawnOffset;

    public float hitRadius = 0.5f;

    public float speed = 10f;

    private int damage = 0;

    private bool canMove = true;

    private bool hasHit = false;

    void Start(){

        flame = Instantiate(flameEffectPrefab);

        flame.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);

        damage = missileTurretPrefab.GetComponent<MissileTurret>().damage;

        soundManager = FindObjectOfType<SoundManager>();

        soundManager.MissileSpawn();

        Invoke("Destroy", 10f);
        
    }

    void Update(){

        if (canMove){

            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

            flame.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

        }

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f), new Vector3(0f, 0f, hitRadius), Color.red);

        Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), new Vector3(0f, 0f, hitRadius));

        if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius)){

            if (hasHit) { return; }

            if(hit.transform.gameObject.tag == "Ghoul"){

                hasHit = true;

                Debug.Log("Missile hit");

                Hit(hit.transform.gameObject);

            }

        }

    }

    private void Hit(GameObject enemy){

        soundManager.MissileExplosion();

        enemy.GetComponent<Ghoul>().TakeDamage(damage);

        GameObject effect = Instantiate(hitEffectPrefab);

        effect.transform.position = transform.position + spawnOffset;

        Destroy(effect, 5f);

        Destroy(gameObject);

    }

    private void Destroy(){

        Destroy(gameObject);

        Destroy(flame);
        
    }

}
