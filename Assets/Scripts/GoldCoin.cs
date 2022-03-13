using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour{

    public float destroyDelay = 4f;

    public float rotateSpeed = 0.1f;
    
    void Start(){

        Destroy(gameObject, destroyDelay);
        
    }

    void Update(){

        transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        
    }

}
