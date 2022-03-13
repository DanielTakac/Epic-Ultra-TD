using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawnmower : MonoBehaviour{

    public GameObject unactiveParticlePrefab;

    public GameObject activeParticlePrefab;

    private GameObject unactiveParticle;

    private GameObject activeParticle;

    public float speed = 10f;

    public bool activated = false;

    private bool canMove = true;

    public void Activate(){

        if (activated) { return; }

        Destroy(unactiveParticle);

        activeParticle = Instantiate(activeParticlePrefab, transform);

        activeParticle.transform.position = transform.position;

        activated = true;

    }

    private void Start(){

        unactiveParticle = Instantiate(unactiveParticlePrefab, transform);

        unactiveParticle.transform.position = transform.position;
        
    }

    private void Update(){

        if (activated && canMove){

            transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

        }

        if(gameObject.transform.position.z >= 11.25){

            ReachEnd();

        }
        
    }

    private void ReachEnd(){

        Destroy(gameObject, 2f);

        canMove = false;

    }

}
