using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostedMissile : MonoBehaviour{

    public GameObject flameEffectPrefab;

    private GameObject flame;

    void Start(){

        flame = Instantiate(flameEffectPrefab);

        flame.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.3f);

        Destroy(gameObject, 20f);

    }

    void Update(){

        flame.transform.position = transform.position;
        
    }

    public void Destroy(){

        Destroy(flame);

        Destroy(gameObject);

    }

}
