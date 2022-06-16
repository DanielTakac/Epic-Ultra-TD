using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ghoul : MonoBehaviour {

    [Header("Setup")]

    private SoundManager soundManager;

    public GameObject spawnEffectPrefab;

    public Animation animator;

    private Transform finishLine;

    public GameObject healthBarCanvas;

    public Image healthBar;

    public GameObject damagePopUp;

    public GameObject boostPopUp;

    private float endPosition;

    private float attackTimer;

    public bool canMove = false;

    public bool paused = false;

    private bool hasDied = false;

    [Header("Game Values")]

    public int health = 100;

    private int startHealth;

    public int damage = 1;

    public float speed = 0.1f;

    public float hitRadius = 1f;

    public float attackDelay = 2f;

    public int acquireBoostChange = 3;

    public bool shield = false;

    /*Pepelaugh
    public GameObject ghoulPrefab;
    public float timer = 0;
    */

    void Start() {

        startHealth = health;

        finishLine = GameObject.FindGameObjectWithTag("FinishLine").transform;

        SpawnEffect();

        soundManager = FindObjectOfType<SoundManager>();

        soundManager.GhoulSpawn();

        animator.Play("Idle");

        StartIdle();

        Invoke("StartWalking", 2f);

        InvokeRepeating("CheckPosition", 4f, 0.3f);

        endPosition = finishLine.position.z;

        hasDied = false;

    }

    void Update(){

        if (!hasDied){

            if (healthBarCanvas != null){

                float tempHealth = health;
                float tempStartHealth = startHealth;

                healthBar.fillAmount = tempHealth / tempStartHealth;

            }

        }else{

            healthBarCanvas.SetActive(false);

        }

        if(health <= 0 && hasDied == false){

            hasDied = true;

            canMove = false;

            Death();

        }

        if (canMove) {

            transform.position -= new Vector3(0f, 0f, speed) * Time.deltaTime;

        }

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, -hitRadius), Color.red);

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, -hitRadius * 2f), Color.yellow);

        Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, -hitRadius));

        Ray backRay = new Ray(new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z), new Vector3(0f, 0f, -hitRadius * 2f));

        if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius)){

            if(hit.transform.gameObject.tag == "Tower"){

                attackTimer -= Time.deltaTime;

                canMove = false;

                if (attackTimer <= attackDelay){

                    attackTimer = attackDelay;

                    int rand = Random.Range(1, 2);

                    if (rand == 1){

                        animator.Play("Attack1");

                    }

                    if (rand == 2){

                        animator.Play("Attack2");

                    }

                    Attack(hit);

                }

            }

        }
        else
        {

            if(paused == false && hasDied == false){

                StartWalking();

            }

        }

        if (Physics.Raycast(backRay, out RaycastHit backHit, hitRadius * 2f)){

            if (backHit.transform.gameObject.tag == "Lawnmower" && hasDied == false){

                if(backHit.transform.parent.gameObject.GetComponent<Lawnmower>() == null){

                    Debug.LogWarning("hit.lawnmower = null!");
                    return;

                }

                backHit.transform.parent.gameObject.GetComponent<Lawnmower>().Activate();

                hasDied = true;

                canMove = false;

                Death();

            }

        }

    }

    private void SpawnEffect(){

        GameObject effect = Instantiate(spawnEffectPrefab);

        effect.transform.position = transform.position;

        Destroy(effect, 3f);

    }

    public void Death(){

        animator.Play("Death");

        int rand = Random.Range(1, 4);

        if(rand == 1) { soundManager.GhoulDeath1(); }
        if(rand == 2) { soundManager.GhoulDeath2(); }
        if(rand == 3) { soundManager.GhoulDeath3(); }

        int boostRand = Random.Range(1, acquireBoostChange + 1);

        if (boostRand == 1){

            GameObject canvas = Instantiate(boostPopUp, transform);

            BoostShop.boosts++;

        }

        Destroy(gameObject, 1f);

        GameManager.money += 25;

    }

    private void Attack(RaycastHit hit){

        Debug.Log("Ghoul Attacking");

        soundManager.GhoulAttack();

        TowerHealth tower = hit.transform.gameObject.GetComponent<TowerHealth>();

        tower.TakeDamage(damage);

        if (tower.Health <= 0){

            tower.destroyedBy = gameObject;

        }

    }

    public void StartWalking(){

        animator.Play("Walk");

        canMove = true;

        paused = false;

    }

    public void StartIdle(){

        animator.Play("Idle");

        canMove = false;

        paused = true;

    }

    private void CheckPosition(){

        if(transform.position.z <= endPosition){

            GameManager.lives = 0;

            Debug.Log("Life Lost");

            Destroy(gameObject, 0.1f);

        }

    }

    public void TakeDamage(int damage){

        if(shield == false){

            health -= damage;

            GameObject popUp = Instantiate(damagePopUp, healthBarCanvas.transform);

            popUp.GetComponent<DamagePopupAnim>().damage = damage;

        }

    }

    public void GetShield(){

        shield = true;

    }

    public void BreakShield(){

        shield = false;

    }

}
