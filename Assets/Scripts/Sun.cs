using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour{

    public float fallSpeed = 0.2f;

    void Update(){

        //Moves the sun down
        transform.localPosition -= new Vector3(0f, fallSpeed, 0f) * Time.deltaTime;

        //Checks if the sun is below the screen
        if(transform.localPosition.y <= -300f){

            Destroy(gameObject);

        }
        
    }

    public void GetMoney(){

        Debug.Log("Money Gained");

        GameManager.money += 50;

        Destroy(gameObject);

    }

}
