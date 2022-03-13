using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour{

    [Header("Setup")]

    public GameObject deathEffectPrefab;

    private bool hasDied = false;

    [Header ("Game Values")]

    public int health = 100;

    public bool shield = false;

    [Header ("Dont Asign In Editor")]

    public GameObject destroyedBy;

    void Update(){

        if(health <= 0 && hasDied == false){

            DestroyTower();

            hasDied = true;

        }
        
    }

    private void DestroyTower(){

        GameObject effect = Instantiate(deathEffectPrefab);

        effect.transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        Destroy(effect, 3f);

        Debug.Log("Tower Destroyed");

        destroyedBy.GetComponent<Ghoul>().Invoke("StartIdle", 0.4f);
        destroyedBy.GetComponent<Ghoul>().Invoke("StartWalking", 2.4f);

        Destroy(gameObject, 0.2f);

    }

    public void TakeDamage(int damage){

        if (shield == false){

            health -= damage;

        }

    }

    public void GetShield(){

        shield = true;

    }

    public void BreakShield(){

        shield = false;

    }

}
