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
    public MeshRenderer mesh10;
    public MeshRenderer mesh11;
    public MeshRenderer mesh12;

    private Material originalMat1;
    private Material originalMat2;
    private Material originalMat3;
    private Material originalMat4;
    private Material originalMat5;
    private Material originalMat6;
    private Material originalMat7;
    private Material originalMat8;
    private Material originalMat9;
    private Material originalMat10;
    private Material originalMat11;
    private Material originalMat12;

    public Material hoverMat;

    public bool activated = false;

    [Header("Game Values")] 
    
    public float boostLength;

    private bool stage1 = false;
    private bool stage2 = false;

    private void OnMouseEnter() {

        if (BoostShop.boostSelected) {

            mesh1.material = hoverMat;
            mesh2.material = hoverMat;
            mesh3.material = hoverMat;
            mesh4.material = hoverMat;
            mesh5.material = hoverMat;
            mesh6.material = hoverMat;
            mesh7.material = hoverMat;
            mesh8.material = hoverMat;
            mesh9.material = hoverMat;
            mesh10.material = hoverMat;
            mesh11.material = hoverMat;
            mesh12.material = hoverMat;

        }

    }

    private void OnMouseExit() {

        if (BoostShop.boostSelected) {

            mesh1.material = originalMat1;
            mesh2.material = originalMat2;
            mesh3.material = originalMat3;
            mesh4.material = originalMat4;
            mesh5.material = originalMat5;
            mesh6.material = originalMat6;
            mesh7.material = originalMat7;
            mesh8.material = originalMat8;
            mesh9.material = originalMat9;
            mesh10.material = originalMat10;
            mesh11.material = originalMat11;
            mesh12.material = originalMat12;

        }

    }

    private void OnMouseDown() {

        Cursor.SetCursor(whiteCursor, Vector2.zero, CursorMode.ForceSoftware);

        if (BoostShop.boostSelected && activated == false) {

            mesh1.material = originalMat1;
            mesh2.material = originalMat2;
            mesh3.material = originalMat3;
            mesh4.material = originalMat4;
            mesh5.material = originalMat5;
            mesh6.material = originalMat6;
            mesh7.material = originalMat7;
            mesh8.material = originalMat8;
            mesh9.material = originalMat9;
            mesh10.material = originalMat10;
            mesh11.material = originalMat11;
            mesh12.material = originalMat12;

            BoostShop.boostSelected = false;

            BoostShop.boosts--;

            Activate();

        }

    }

    void Start() {

        originalMat1 = mesh1.material;
        originalMat2 = mesh2.material;
        originalMat3 = mesh3.material;
        originalMat4 = mesh4.material;
        originalMat5 = mesh5.material;
        originalMat6 = mesh6.material;
        originalMat7 = mesh7.material;
        originalMat8 = mesh8.material;
        originalMat9 = mesh9.material;
        originalMat10 = mesh10.material;
        originalMat11 = mesh11.material;
        originalMat12 = mesh12.material;

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

        Invoke("Stage2", boostLength);

    }

    private void Stage2(){

        stage1 = false;
        stage2 = true;

        activated = false;

        gameObject.GetComponent<MinigunTurret>().isBoosted = false;

    }
}
