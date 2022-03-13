using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoostShop : MonoBehaviour{

    public Texture2D whiteCursor;
    public Texture2D pinkCursor;

    public Image image;

    public Text boostText;

    private Color originalColor;

    public Color selectedColor;

    public static int boosts;

    public static bool boostSelected = false;

    void Start(){

        boosts = PlayerPrefs.GetInt("boost");

        originalColor = image.color;

        InvokeRepeating("Save", 0.1f, 0.2f);
        
    }

    private void Save(){

        PlayerPrefs.SetInt("boost", boosts);

        boostText.text = boosts.ToString();

        if(boostSelected == false){

            image.color = originalColor;

        }

    }

    public void ClickBoost(){

        //if(boosts <= 0) { return; }

        if (boostSelected){

            boostSelected = false;

            image.color = originalColor;

            Cursor.SetCursor(whiteCursor, Vector2.zero, CursorMode.ForceSoftware);

        }else{

            boostSelected = true;

            image.color = selectedColor;

            Cursor.SetCursor(pinkCursor, Vector2.zero, CursorMode.ForceSoftware);

        }

    }

}
