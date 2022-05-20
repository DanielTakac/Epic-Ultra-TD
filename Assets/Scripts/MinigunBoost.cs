using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBoost : MonoBehaviour{

    [Header("Setup")]

    public Texture2D whiteCursor;

    private SoundManager soundManager;

    private GameObject[] enemies;

    public MeshRenderer mesh1;

    private Material originalMat1;

    public Material hoverMat;

    public bool activated = false;

    private bool stage1 = false;

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

        gameObject.GetComponent<MinigunTurret>().canShoot = false;

        activated = true;

        Stage1();

    }

    private void Stage1() {

        stage1 = true;

    }
}
