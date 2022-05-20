using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBoost : MonoBehaviour{

    [Header("Setup")]

    public Texture2D whiteCursor;

    private SoundManager soundManager;

    private GameObject[] enemies;

    public MeshRenderer mesh1;
    public MeshRenderer mesh2;
    public MeshRenderer mesh3;
    public MeshRenderer mesh4;
    public MeshRenderer mesh5;
    public MeshRenderer mesh6;
    public MeshRenderer mesh7;
    public MeshRenderer mesh8;
    public MeshRenderer mesh9;

    private Material originalMat1;

    public Material hoverMat;

    public bool activated = false;

    private bool stage1 = false;
    private bool stage2 = false;

    private void OnMouseEnter() {

        if (BoostShop.boostSelected) {

            mesh1.material = hoverMat;

        }

    }

    private void OnMouseExit() {

        if (BoostShop.boostSelected) {

            mesh1.material = originalMat1;

        }

    }

    private void OnMouseDown() {

        Cursor.SetCursor(whiteCursor, Vector2.zero, CursorMode.ForceSoftware);

        if (BoostShop.boostSelected && activated == false) {

            mesh1.material = originalMat1;

            BoostShop.boostSelected = false;

            BoostShop.boosts--;

            Activate();

        }

    }

    void Start() {

        originalMat1 = mesh1.material;

        soundManager = FindObjectOfType<SoundManager>();

    }

    void Update() {

        if (Input.GetKeyDown("space")){

            Activate();

        }

    }

    public void Activate() {

        if (activated) return;

        activated = true;

        Stage1();

    }

    private void Stage1() {

        stage1 = true;

        gameObject.GetComponent<MinigunTurret>().isBoosted = true;

    }

    private void Stage2(){

        stage1 = false;
        stage2 = true;

        gameObject.GetComponent<MinigunTurret>().isBoosted = false;

    }
}
