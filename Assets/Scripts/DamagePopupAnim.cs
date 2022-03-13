using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DamagePopupAnim : MonoBehaviour{

    public Animation anim;

    private Text text;

    public int damage;

    private void Start(){

        text = gameObject.GetComponent<Text>();

    }

    private void Update(){

        text.text = damage.ToString("F0");
        
    }

    public void DestroyOnEnd(){

        Destroy(gameObject);

    }

}
