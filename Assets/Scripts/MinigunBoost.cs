using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBoost : TurretBoost {

    [Header("Game Values")] 
    
    public float boostLength;

    public override void Activate() {

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
