using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBoost : TurretBoost {

    [Header("Setup")]

    public Texture2D whiteCursor;

    private SoundManager soundManager;

    public GameObject missilePrefab;

    public Transform rotatePart;

    private GameObject[] enemies;

    private GameObject[] missile;

    public MeshRenderer mesh1;
    public MeshRenderer mesh2;
    public MeshRenderer mesh3;
    public MeshRenderer mesh4;
    public MeshRenderer mesh5;
    public MeshRenderer mesh6;
    public MeshRenderer mesh7;

    private Material originalMat1;
    private Material originalMat2;
    private Material originalMat3;
    private Material originalMat4;
    private Material originalMat5;
    private Material originalMat6;
    private Material originalMat7;

    public Material hoverMat;

    public bool activated = false;

    private bool stage1 = false;

    private bool stage3 = false;

    private bool stage4 = false;

    private bool noEnemies = false;

    [Header("Game Values")]

    public Vector3 missileSpawnOffSet;

    public float rotateSpeed = 10f;

    public float flyUpSpeed = 10f;

    public float flySpeed = 15f;

    public float maxHeight = 10f;

    private void OnMouseEnter(){

        if (BoostShop.boostSelected){

            mesh1.material = hoverMat;
            mesh2.material = hoverMat;
            mesh3.material = hoverMat;
            mesh4.material = hoverMat;
            mesh5.material = hoverMat;
            mesh6.material = hoverMat;
            mesh7.material = hoverMat;

        }

    }

    private void OnMouseExit(){

        if (BoostShop.boostSelected){

            mesh1.material = originalMat1;
            mesh2.material = originalMat2;
            mesh3.material = originalMat3;
            mesh4.material = originalMat4;
            mesh5.material = originalMat5;
            mesh6.material = originalMat6;
            mesh7.material = originalMat7;

        }

    }

    private void OnMouseDown(){

        Cursor.SetCursor(whiteCursor, Vector2.zero, CursorMode.ForceSoftware);

        if (BoostShop.boostSelected && activated == false){

            mesh1.material = originalMat1;
            mesh2.material = originalMat2;
            mesh3.material = originalMat3;
            mesh4.material = originalMat4;
            mesh5.material = originalMat5;
            mesh6.material = originalMat6;
            mesh7.material = originalMat7;

            BoostShop.boostSelected = false;

            BoostShop.boosts--;

            Activate();

        }

    }

    void Start(){

        originalMat1 = mesh1.material;
        originalMat2 = mesh2.material;
        originalMat3 = mesh3.material;
        originalMat4 = mesh4.material;
        originalMat5 = mesh5.material;
        originalMat6 = mesh6.material;
        originalMat7 = mesh7.material;

        soundManager = FindObjectOfType<SoundManager>();

    }

    void Update(){

        if (noEnemies){

            if (rotatePart.localRotation.x <= 0f){

                rotatePart.eulerAngles = new Vector3(0f, 0f, 0f);
                noEnemies = false;
                Stage5();
                return;

            }

            rotatePart.Rotate(rotateSpeed * Time.deltaTime, 0f, 0f);

        }

        /*if (Input.GetKeyDown("space")){

            Activate();

        }*/

        if (stage1){

            if(rotatePart.localRotation.x <= -0.7){

                Stage2();

                rotatePart.eulerAngles = new Vector3(270f, 0f, 0f);

                return;

            }

            rotatePart.Rotate(-rotateSpeed * Time.deltaTime, 0f, 0f);

        }

        if (stage3){

            for (int i = 0; i < missile.Length; i++){

                missile[i].transform.position += new Vector3(0f, flyUpSpeed * Time.deltaTime, 0f);

            }

            if(missile[0].transform.position.y >= maxHeight){

                soundManager.MissileBoost();

                Stage4();

            }

        }

        if (stage4){

            if (enemies[0] == null && missile[0] == null){

                Invoke("Stage5", 2f);

            }

            for (int i = 0; i < missile.Length; i++){

                if (enemies[i] != null && missile[i] != null){

                    Vector3 direction = missile[i].transform.position - enemies[i].transform.position + new Vector3(0f, -1f, 0f);
                    
                    direction = -direction.normalized;

                    missile[i].transform.position += direction * Time.deltaTime * flySpeed;

                    if (Vector3.Distance(missile[i].transform.position, enemies[i].transform.position) <= 1f){

                        if (enemies[i].GetComponent<Ghoul>() == null){

                            return;

                        }

                        soundManager.MissileExplosion();

                        enemies[i].GetComponent<Ghoul>().TakeDamage(500);

                        Destroy(missile[i]);

                    }

                }

                if (enemies[i] == null && missile[i] != null){

                    missile[i].transform.position -= new Vector3(0f, -flyUpSpeed * Time.deltaTime, 0f);

                }

            }

            if (rotatePart.localRotation.x <= 0f){

                rotatePart.eulerAngles = new Vector3(0f, 0f, 0f);
                return;

            }

            rotatePart.Rotate(rotateSpeed * Time.deltaTime, 0f, 0f);

        }
        
    }

    public void Activate(){

        if (activated) return;

        gameObject.GetComponent<MissileTurret>().canShoot = false;

        activated = true;

        Stage1();

    }

    private void Stage1(){

        stage1 = true;

    }

    private void Stage2(){

        stage1 = false;

        enemies = GameObject.FindGameObjectsWithTag("Ghoul");

        missile = new GameObject[enemies.Length];

        if (enemies.Length == 0){

            noEnemies = true;
            return;
            
        }

        for (int i = 0; i < enemies.Length; i++){

            missile[i] = Instantiate(missilePrefab);

            missile[i].transform.position = transform.position + missileSpawnOffSet;

        }

        soundManager.MissileSpawn();

        Stage3();

    }

    private void Stage3(){

        stage3 = true;

    }

    private void Stage4(){

        stage3 = false;
        stage4 = true;

        for (int i = 0; i < missile.Length; i++){

            if(enemies[i] == null){

                missile[i].transform.eulerAngles = new Vector3(90f, 0f, 0f);
                return;

            }

            if (enemies[i].transform.position.z >= transform.position.z){

                missile[i].transform.eulerAngles = new Vector3(40f, 0f, 0f);

            }
            else
            {

                missile[i].transform.eulerAngles = new Vector3(320f, 0f, 0f);

            }

        }

    }

    private void Stage5(){

        stage1 = false;
        stage3 = false;
        stage4 = false;
        activated = false;

        gameObject.GetComponent<MissileTurret>().canShoot = true;

    }

}
