using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoyagerBoost : TurretBoost {

    [Header("Setup")]

    public Texture2D whiteCursor;

    private SoundManager soundManager;

    private GameObject[] laser;

    private GameObject[] currentEnemies;

    public GameObject laserPrefab;

    public GameObject lightPrefab;

    private GameObject lightEffect;

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
    public MeshRenderer mesh13;
    public MeshRenderer mesh14;
    public MeshRenderer mesh15;
    public MeshRenderer mesh16;
    public MeshRenderer mesh17;
    public MeshRenderer mesh18;
    public MeshRenderer mesh19;
    public MeshRenderer mesh20;
    public MeshRenderer mesh21;
    public MeshRenderer mesh22;

    private Material originalMat;

    public Material hoverMat;

    private int laserLength;

    private bool activated = false;

    private bool stage1 = false;

    [Header("Game Values")]

    public Vector3 laserSpawnOffSet;

    public float maxDistance;

    public float boostLength;

    public int damage = 1;

    public float hitRadius = 30f;

    private void OnMouseEnter(){

        if (BoostShop.boostSelected){

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
            mesh13.material = hoverMat;
            mesh14.material = hoverMat;
            mesh15.material = hoverMat;
            mesh16.material = hoverMat;
            mesh17.material = hoverMat;
            mesh18.material = hoverMat;
            mesh19.material = hoverMat;
            mesh20.material = hoverMat;
            mesh21.material = hoverMat;
            mesh22.material = hoverMat;

        }

    }

    private void OnMouseExit(){

        if (BoostShop.boostSelected){

            mesh1.material = originalMat;
            mesh2.material = originalMat;
            mesh3.material = originalMat;
            mesh4.material = originalMat;
            mesh5.material = originalMat;
            mesh6.material = originalMat;
            mesh7.material = originalMat;
            mesh8.material = originalMat;
            mesh9.material = originalMat;
            mesh10.material = originalMat;
            mesh11.material = originalMat;
            mesh12.material = originalMat;
            mesh13.material = originalMat;
            mesh14.material = originalMat;
            mesh15.material = originalMat;
            mesh16.material = originalMat;
            mesh17.material = originalMat;
            mesh18.material = originalMat;
            mesh19.material = originalMat;
            mesh20.material = originalMat;
            mesh21.material = originalMat;
            mesh22.material = originalMat;

        }

    }

    private void OnMouseDown(){

        Cursor.SetCursor(whiteCursor, Vector2.zero, CursorMode.ForceSoftware);

        if (BoostShop.boostSelected && activated == false){

            mesh1.material = originalMat;
            mesh2.material = originalMat;
            mesh3.material = originalMat;
            mesh4.material = originalMat;
            mesh5.material = originalMat;
            mesh6.material = originalMat;
            mesh7.material = originalMat;
            mesh8.material = originalMat;
            mesh9.material = originalMat;
            mesh10.material = originalMat;
            mesh11.material = originalMat;
            mesh12.material = originalMat;
            mesh13.material = originalMat;
            mesh14.material = originalMat;
            mesh15.material = originalMat;
            mesh16.material = originalMat;
            mesh17.material = originalMat;
            mesh18.material = originalMat;
            mesh19.material = originalMat;
            mesh20.material = originalMat;
            mesh21.material = originalMat;
            mesh22.material = originalMat;

            BoostShop.boostSelected = false;

            BoostShop.boosts--;

            Activate();

        }

    }

    void Start(){

        soundManager = FindObjectOfType<SoundManager>();

        originalMat = mesh1.material;

        InvokeRepeating("SlowUpdate", 1f, 0.3f);

    }

    void Update(){

        /*if (Input.GetKeyDown("space")){

            Activate();

        }*/

        /*if (stage1){

            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), new Vector3(0f, 0f, hitRadius), Color.white);

            Ray myRay = new Ray(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), new Vector3(0f, 0f, hitRadius));

            if (Physics.Raycast(myRay, out RaycastHit hit, hitRadius)){

                if (hit.transform.gameObject.tag == "Ghoul"){

                    hit.transform.gameObject.GetComponent<Ghoul>().TakeDamage(damage);

                }

            }

        }*/

    }

    private void FixedUpdate(){

        if (stage1 && currentEnemies != null){

            for (int i = 0; i < currentEnemies.Length; i++){

                if (currentEnemies[i] != null && currentEnemies[i].transform.position.x == transform.position.x){

                    currentEnemies[i].GetComponent<Ghoul>().TakeDamage(damage);

                }

            }

        }
        
    }

    private void SlowUpdate(){

        currentEnemies = GameObject.FindGameObjectsWithTag("Ghoul");

    }

    public void Activate(){

        if (activated) return;

        activated = true;

        Stage1();

    }

    private void Stage1(){

        soundManager.LaserSpawn();

        laser = new GameObject[25];

        float spawnDistance = 0f;

        laserLength = 25;

        for (int i = 0; i < laser.Length; i++){

            laser[i] = Instantiate(laserPrefab);

            laser[i].transform.position = transform.position + laserSpawnOffSet + new Vector3(0f, 0f, spawnDistance);

            if (laser[i].transform.position.z > maxDistance){

                laserLength--;

                Destroy(laser[i]);

            }

            spawnDistance += 0.5f;

        }

        stage1 = true;

        Invoke("Stage2", boostLength);

    }

    private void Stage2(){

        activated = false;

        for (int i = 0; i < laserLength; i++){

            Destroy(laser[i]);

        }

    }

}
