using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FrameCounter : MonoBehaviour{

    [Header("Setup")]

    public GameObject object1;
    public GameObject object2;
    public GameObject object3;
    public GameObject object4;

    public Text fpsText;

    public Text frameTimeText;

    [Header ("Game Values")]

    public float refreshDelay = 0.1f;

    private float frameTime;

    private float fps;

    public bool showFps = false;

    private void Start(){

        InvokeRepeating("RefreshText", 0.1f, refreshDelay);
        
    }

    void Update(){

        frameTime = Time.deltaTime;

        fps = 1 / Time.deltaTime;

    }

    private void RefreshText(){

        if (showFps){

            frameTimeText.text = frameTime.ToString("F3");

            fpsText.text = fps.ToString("F0");

        }

    }

    public void EnableFPS(){

        object1.SetActive(true);
        object2.SetActive(true);
        object3.SetActive(true);
        object4.SetActive(true);

        showFps = true;

    }

    public void DisableFPS(){

        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
        object4.SetActive(false);

        showFps = false;

    }

}
