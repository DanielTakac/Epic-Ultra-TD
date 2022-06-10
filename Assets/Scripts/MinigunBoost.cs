using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBoost : TurretBoost {

    [Header("Setup")]

    private GameObject[] enemies;

    [Header("Game Values")] 
    
    public float boostLength;

    void Start() {

        originalMat1 = mesh1.material;
        originalMat2 = mesh2.material;
        originalMat3 = mesh3.material;
        originalMat4 = mesh4.material;
        originalMat5 = mesh5.material;
        originalMat6 = mesh6.material;
        originalMat7 = mesh7.material;
        originalMat8 = mesh8.material;
        originalMat9 = mesh9.material;
        originalMat10 = mesh10.material;
        originalMat11 = mesh11.material;
        originalMat12 = mesh12.material;

        soundManager = FindObjectOfType<SoundManager>();

    }

    protected override void Activate() {

        if (activated) return;

        activated = true;

        Stage1();

    }

    private void Stage1() {

        gameObject.GetComponent<MinigunTurret>().isBoosted = true;

        Invoke("Stage2", boostLength);

    }

    private void Stage2(){

        activated = false;

        gameObject.GetComponent<MinigunTurret>().isBoosted = false;

    }
}
