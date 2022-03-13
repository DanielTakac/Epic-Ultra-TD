using System.Collections;
using System.Collections.Generic;
using DigitalRuby.LightningBolt;
using UnityEngine;

public class TeslaTurret : MonoBehaviour{

    [Header("Setup")]

    public GameObject coil1;
    public GameObject coil2;
    public GameObject coil3;
    public GameObject coil4;

    public GameObject linePrefab;

    private SoundManager soundManager;

    [Header("Game Values")]

    private float attackTimer1 = 0f;
    private float attackTimer2 = 0f;
    private float attackTimer3 = 0f;
    private float attackTimer4 = 0f;

    public float attackDelay = 1f;

    public float lineLifeSpan = 0.5f;

    public int damage = 12;

    public bool canShoot = true;

    private void OnTriggerStay (Collider other){

        if(other.gameObject.tag == "Ghoul"){

            if(canShoot == false) { return; }

            bool hasAttacked = false;

            if (attackTimer1 <= 0f && !hasAttacked){

                hasAttacked = true;

                attackTimer1 = attackDelay;

                Hit(other.transform.Find("Target").gameObject, coil1);

            }

            if (attackTimer2 <= 0f && !hasAttacked){

                hasAttacked = true;

                attackTimer2 = attackDelay;

                Hit(other.transform.Find("Target").gameObject, coil2);

            }

            if (attackTimer3 <= 0f && !hasAttacked){

                hasAttacked = true;

                attackTimer3 = attackDelay;

                Hit(other.transform.Find("Target").gameObject, coil3);

            }

            if (attackTimer4 <= 0f && !hasAttacked){

                hasAttacked = true;

                attackTimer4 = attackDelay;

                Hit(other.transform.Find("Target").gameObject, coil4);

            }

        }
        
    }

    void Start(){

        soundManager = FindObjectOfType<SoundManager>();
        
    }

    void Update(){

        attackTimer1 -= Time.deltaTime;
        attackTimer2 -= Time.deltaTime;
        attackTimer3 -= Time.deltaTime;
        attackTimer4 -= Time.deltaTime;
        
    }

    private void Hit(GameObject enemy, GameObject coil){

        enemy.GetComponentInParent<Ghoul>().TakeDamage(damage);

        GameObject line = Instantiate(linePrefab);

        line.transform.position = transform.position;

        line.GetComponent<LightningBoltScript>().StartObject = coil;

        line.GetComponent<LightningBoltScript>().EndObject = enemy;

        Destroy(line, lineLifeSpan);

        int rand = Random.Range(1, 3);

        if (rand == 1) { soundManager.TeslaAttack1(); }
        if (rand == 2) { soundManager.TeslaAttack2(); }

    }

}
