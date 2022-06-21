using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class FrameCounter : MonoBehaviour {

    [Header("Setup")]

    [SerializeField] private Text fpsText;
    [SerializeField] private Text frameTimeText;
    [SerializeField] private Text minFpsText;
    [SerializeField] private Text maxFpsText;
    [SerializeField] private Text averageFpsText;

    [Header ("Game Values")]

    public float refreshDelay = 0.1f;

    private float fps;
    private float frameTime;
    private float minFps = float.MaxValue;
    private float maxFps = 0;
    private float averageFPS;

    private List<float> fpsList = new List<float>();

    private bool showFps = true;

    private bool bufferTime = true;

    private void Start() {

        InvokeRepeating("RefreshText", 0.1f, refreshDelay);

        InvokeRepeating("AddFPSToList", 0.1f, 0.2f);
        
        InvokeRepeating("ResetFPSValues", 0.1f, 5f);

        Invoke("DisableBufferTime", 1.5f);

    }

    void Update() {

        frameTime = Time.deltaTime;

        fps = 1 / Time.deltaTime;

        averageFPS = fpsList.Sum() / fpsList.Count;

        // So first few seconds don't count because of lag
        if (bufferTime) return;

        if (fps < minFps) minFps = fps;
        if (fps > maxFps) maxFps = fps;

    }

    private void DisableBufferTime() => bufferTime = false;

    private void AddFPSToList() => fpsList.Add(fps);

    private void ResetFPSValues() => fpsList.Clear();

    private void RefreshText() {

        if (showFps) {

            fpsText.text = fps.ToString("F0");
            frameTimeText.text = frameTime.ToString("F3");
            minFpsText.text = minFps.ToString("F0");
            maxFpsText.text = maxFps.ToString("F0");
            averageFpsText.text = averageFPS.ToString("F0");

        }

    }

    public void EnableFPS() {

        foreach (Transform child in transform) child.gameObject.SetActive(true);

        showFps = true;

    }

    public void DisableFPS(){

        foreach (Transform child in transform) child.gameObject.SetActive(true);

        showFps = false;

    }

}
