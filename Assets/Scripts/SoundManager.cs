using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine;

public class SoundManager : MonoBehaviour{

    public GameObject menu;

    public GameObject blurEffect;

    private bool soundEnabled;

    private bool previousCheck = false;

    public float volumeChange;

    [Header("Audio Sources")]

    public AudioSource ghoulSpawn;
    public AudioSource turretSpawn;
    public AudioSource buttonHover;
    public AudioSource getBoost;
    public AudioSource missileExplosion;
    public AudioSource missileSpawn;
    public AudioSource ghoulAttack;
    public AudioSource laserSpawn;
    public AudioSource laserHit;
    public AudioSource missileBoost;
    public AudioSource ghoulDeath1;
    public AudioSource ghoulDeath2;
    public AudioSource ghoulDeath3;
    public AudioSource teslaAttack1;
    public AudioSource teslaAttack2;

    void Start(){

        InvokeRepeating("LoadPrefs", 0f, 0.5f);

        InvokeRepeating("SlowUpdate", 0f, 0.1f);
        
    }

    private void SlowUpdate(){

        if (menu.activeSelf){

            if (!previousCheck){

                VolumeDown();

                EnableBlur();

            }

            previousCheck = true;

        }
        else
        {

            if (previousCheck){

                VolumeUp();

                DisableBlur();

            }

            previousCheck = false;

        }

    }

    private void DisableBlur(){

        blurEffect.SetActive(false);

    }

    private void EnableBlur(){

        blurEffect.SetActive(true);

    }

    private void VolumeDown(){

        foreach(Transform child in transform){

            child.GetComponent<AudioSource>().volume -= volumeChange;

        }

    }

    private void VolumeUp(){

        foreach (Transform child in transform){

            child.GetComponent<AudioSource>().volume += volumeChange;

        }

    }

    private void LoadPrefs(){

        if (PlayerPrefs.GetInt("soundEnabled") == 0){

            soundEnabled = false;

        }
        
        if (PlayerPrefs.GetInt("soundEnabled") == 1){

            soundEnabled = true;

        }

    }

    public void GhoulSpawn(){

        if(soundEnabled == false) { return; }

        ghoulSpawn.Play();

    }

    public void TurretSpawn(){

        if (soundEnabled == false) { return; }

        turretSpawn.Play();

    }

    public void ButtonHover(){

        if (soundEnabled == false) { return; }

        buttonHover.Play();

    }

    public void GetBoost(){

        if (soundEnabled == false) { return; }

        getBoost.Play();

    }

    public void MissileExplosion(){

        if (soundEnabled == false) { return; }

        missileExplosion.Play();

    }

    public void MissileSpawn(){

        if (soundEnabled == false) { return; }

        missileSpawn.Play();

    }

    public void GhoulAttack(){

        if (soundEnabled == false) { return; }

        ghoulAttack.Play();

    }

    public void LaserSpawn(){

        if (soundEnabled == false) { return; }

        laserSpawn.Play();

    }

    public void LaserHit(){

        if (soundEnabled == false) { return; }

        laserHit.Play();

    }

    public void MissileBoost(){

        if (soundEnabled == false) { return; }

        missileBoost.Play();

    }

    public void GhoulDeath1(){

        if (soundEnabled == false) { return; }

        ghoulDeath1.Play();

    }

    public void GhoulDeath2(){

        if (soundEnabled == false) { return; }

        ghoulDeath2.Play();

    }

    public void GhoulDeath3(){

        if (soundEnabled == false) { return; }

        ghoulDeath3.Play();

    }

    public void TeslaAttack1(){

        if (soundEnabled == false) { return; }

        teslaAttack1.Play();

    }

    public void TeslaAttack2(){

        if (soundEnabled == false) { return; }

        teslaAttack2.Play();    

    }

}
