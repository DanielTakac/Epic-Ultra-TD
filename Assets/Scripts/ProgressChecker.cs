using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class ProgressChecker : MonoBehaviour{

    [SerializeField] GameObject[] lines;

    public bool[] levelEnabled = new bool[10];

    void Start(){

        for (int i = 1; i < 10; i++){

            if (PlayerPrefs.GetInt($"level{i}") == 1){

                EnableLevel(i);

                Debug.LogError($"Enable {i}");

            } else {
                
                DisableLevel(i);

                Debug.LogError($"Disable {i}");

            }

        }
        
    }

    private void EnableLevel(int index){

        lines[index - 1].SetActive(true);

    }

    private void DisableLevel(int index){

        lines[index - 1].SetActive(false);

    }
    
}
