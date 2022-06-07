using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelLoader : MonoBehaviour{

    public GameObject loadingScreen;

    public Image circle;

    public Text text;

    public Text levelText;

    public void LoadLevel(int sceneIndex){

        // Check if the previous level has been beaten
        if (sceneIndex == 1 || PlayerPrefs.GetInt($"level{sceneIndex - 1}") == 1) {

            // Add custom check for level 0 later

            GameObject.FindObjectOfType<LevelIndexManager>().levelIndex = sceneIndex;

            StartCoroutine(LoadAsynchronously(sceneIndex));

        }

    }

    IEnumerator LoadAsynchronously(int level){

        loadingScreen.SetActive(true);

        levelText.text = (level).ToString("F0");

        circle.fillAmount = 0;
        text.text = "0";

        yield return new WaitForSeconds(0.5f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        while (!operation.isDone){

            float progress = Mathf.Clamp01(operation.progress / 0.9f) * 100;

            Debug.Log(progress);

            circle.fillAmount = progress;
            text.text = progress.ToString("F0");

            yield return null;

        }

    }

}
