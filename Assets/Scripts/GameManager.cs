using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour{

    [Header ("Setup")]

    public GameObject deathScreen;

    public Text livesText;

    public Text moneyText;

    public GameObject mainCamera;

    public GameObject menu;

    public PostProcessVolume chromaticVolume;

    [Header ("Game Values")]

    public static int lives = 100;

    public static int money = 0;

    public float vfxSpeed = 0.05f;

    private bool levelStarting = false;

    void Start(){

        deathScreen.SetActive(false);

        InvokeRepeating("SlowUpdate", 2f, 0.2f);

        LevelStart();
        
    }

    void Update(){

        //Set lives text
        livesText.text = lives.ToString();

        //Set money text
        moneyText.text = money.ToString();

        if(lives <= 0){

            GameOver();

        }

        if (Input.GetKeyDown("escape")){

            menu.SetActive(!menu.activeSelf);

        }

        if (levelStarting){

            chromaticVolume.weight -= vfxSpeed * Time.deltaTime;

            if(chromaticVolume.weight <= 0.01f){

                levelStarting = false;

                chromaticVolume.gameObject.SetActive(false);

            }

        }
        
    }

    private void SlowUpdate(){

        if(PlayerPrefs.GetInt("FXAA") == 0){

            mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;

        }

        if (PlayerPrefs.GetInt("FXAA") == 1){

            mainCamera.GetComponent<PostProcessLayer>().antialiasingMode = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;

        }

    }

    private void LevelStart(){

        chromaticVolume.gameObject.SetActive(true);

        chromaticVolume.weight = 1;

        levelStarting = true;

    }

    public void GameOver(){

        Debug.Log("GameOver");

        deathScreen.SetActive(true);

        Invoke("RestartLevel", 3f);

    }

    private void RestartLevel(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

}
