using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour{

    public GameObject menu;

    public GameObject versionInfo;

    public GameObject nature;

    public GameObject postFX;

    public void RestartScene(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void DisableSound(){

        PlayerPrefs.SetInt("soundEnabled", 0);

    }

    public void EnableSound(){

        PlayerPrefs.SetInt("soundEnabled", 1);

    }

    public void EnableGFX(){

        if(nature != null){

            nature.SetActive(true);

            postFX.SetActive(true);

        }

    }

    public void DisableGFX(){

        if (nature != null){

            nature.SetActive(false);

            postFX.SetActive(false);

        }

    }

    public void DisableFXAA(){

        PlayerPrefs.SetInt("FXAA", 0);

    }

    public void EnableFXAA(){

        PlayerPrefs.SetInt("FXAA", 1);

    }

    public void DisableMenu(){

        menu.SetActive(false);

    }

    public void EnableMenu(){

        menu.SetActive(true);

    }

    public void ToggleMenu(){

        menu.SetActive(!menu.activeSelf);

    }

    public void LoadHomeScene(){

        SceneManager.LoadScene("Home");

        Debug.Log("Home");

    }

    public void ToggleVersionInfo(){

        versionInfo.SetActive(!versionInfo.activeSelf);

    }

}
