using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIndexManager : MonoBehaviour{

    public int levelIndex;

    void Awake(){

        DontDestroyOnLoad(this);
        
    }

}
