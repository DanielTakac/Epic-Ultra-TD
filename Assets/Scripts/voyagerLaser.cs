using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voyagerLaser : MonoBehaviour{

    [Header("Setup")]

    private SoundManager soundManager;

    public GameObject voyagerPrefab;

    public bool canMove = true;

    [Header("Game Values")]

    public float hitRadius = 10f;

    private int damage = 0;

    public float speed = 1f;

    void Start(){

        soundManager = FindObjectOfType<SoundManager>();

        damage = voyagerPrefab.GetComponent<Voyager>().damage;

        Destroy(gameObject, 10f);
        
    }

    void Update(){

        if (canMove){

            transform.position += new Vector3(0f, 0f, speed) * Time.deltaTime;

        }

        Debug.DrawRay(transform.position, new Vector3(0f, 0f, hitRadius), Color.yellow);

        Ray myRay = new Ray(transform.position, new Vector3(0f, 0f, hitRadius));

        Ray backRay = new Ray(transform.position, new Vector3(0f, 0f, -hitRadius * 3));

        if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius)){

            if(hit.transform.gameObject.tag == "Ghoul"){

                HitEnemy(hit.transform.gameObject);

            }

        }

        if (Physics.Raycast(backRay, out RaycastHit backHit, -hitRadius * 3)){

            if (backHit.transform.gameObject.tag == "Ghoul"){

                HitEnemy(backHit.transform.gameObject);

            }

        }

    }

    private void HitEnemy(GameObject enemy){

        soundManager.LaserHit();

        enemy.GetComponent<Ghoul>().TakeDamage(damage);

        Destroy(gameObject);

    }

}
