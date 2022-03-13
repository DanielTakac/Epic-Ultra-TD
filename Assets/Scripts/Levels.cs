using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Levels : MonoBehaviour{

    public GameObject settings;

    public GameObject versionInfo;

    public Transform panel;

    public float speed = 10f;

    void Update(){

        if (Input.GetKey("right") && panel.localPosition.x >= -1500f){

            panel.localPosition -= new Vector3(speed, 0f, 0f) * Time.deltaTime;

        }

        if (Input.GetKey("left") && panel.localPosition.x <= 0f){

            panel.localPosition += new Vector3(speed, 0f, 0f) * Time.deltaTime;

        }

    }

    public void QuitGame(){

        Application.Quit();

        Debug.Log("Quit Game");

    }

    public void LoadLevel00(){

        SceneManager.LoadScene("Level00");

        Debug.Log("Load Level");

    }

    public void ToggleSettings(){

        settings.SetActive(!settings.activeSelf);

    }

    public void DisableSound(){

        PlayerPrefs.SetInt("soundEnabled", 0);

    }

    public void EnableSound(){

        PlayerPrefs.SetInt("soundEnabled", 1);

    }

    public void DisableSettings(){

        settings.SetActive(false);

    }

    public void ToggleVersionInfo(){

        versionInfo.SetActive(!versionInfo.activeSelf);

    }

}
