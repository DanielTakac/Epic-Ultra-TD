using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour {

    [SerializeField] private GameObject deathEffectPrefab;

    private bool hasDied = false;

    [SerializeField] public int Health { get; private set; }

    public bool Shield { get; private set; }

    [Header("Dont Asign In Editor")]
    
    public Tile tile;

    public GameObject destroyedBy;

    private void Start() {

        this.Health = 100;
        
        this.Shield = false;

    }

    void Update() {

        if (Health <= 0 && !hasDied){

            DestroyTower();

            hasDied = true;

        }
        
    }

    private void DestroyTower() {

        tile.hasTower = false;

        GameObject effect = Instantiate(deathEffectPrefab);

        effect.transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        Destroy(effect, 3f);

        destroyedBy.GetComponent<Ghoul>().Invoke("StartIdle", 0.4f);
        destroyedBy.GetComponent<Ghoul>().Invoke("StartWalking", 2.4f);

        Destroy(gameObject, 0.2f);

    }

    public void TakeDamage(int damage) {

        if (!Shield) Health -= damage;

    }

    public void GetShield() => Shield = true;

    public void BreakShield() => Shield = false;

}
