using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    [Header("Setup")]

    private SoundManager soundManager;

    public GameObject voyagerTurretPrefab;
    public GameObject teslaTurretPrefab;
    public GameObject moneyTurretPrefab;
    public GameObject minigunTurretPrefab;
    public GameObject missileTurretPrefab;

    private GameObject clickablePanel;

    private Material originalMaterial;
    public Material hoverMaterial;

    public MeshRenderer mesh;

    private bool hasTower = false;

    [Header ("Prices")]

    public int moneyPrice = 50;
    public int voyagerPrice = 100;
    public int teslaPrice = 125;
    public int minigunPrice = 175;
    public int missilePrice = 250;


    private void OnMouseEnter(){

        mesh.material = hoverMaterial;
        
    }

    private void OnMouseExit(){

        mesh.material = originalMaterial;
        
    }

    private void OnMouseDown(){

        Debug.Log("Tile Pressed");

        if (hasTower){

            return;

        }

        if (TurretShop.moneyClicked){

            TurretShop.moneyClicked = false;
            TurretShop.voyagerClicked = false;
            TurretShop.teslaClicked = false;
            TurretShop.minigunClicked = false;
            TurretShop.missileClicked = false;

            if (GameManager.money >= moneyPrice){

                SpawnMoneyTurret();

                hasTower = true;

            }
            else
            {
                Debug.Log("Not enough money!");
            }

        }

        if (TurretShop.voyagerClicked)
        {

            TurretShop.moneyClicked = false;
            TurretShop.voyagerClicked = false;
            TurretShop.teslaClicked = false;
            TurretShop.minigunClicked = false;
            TurretShop.missileClicked = false;

            if (GameManager.money >= voyagerPrice)
            {

                SpawnVoyagerTurret();

                hasTower = true;

            }
            else
            {
                Debug.Log("Not enough money!");
            }

        }

        if (TurretShop.teslaClicked)
        {

            TurretShop.moneyClicked = false;
            TurretShop.voyagerClicked = false;
            TurretShop.teslaClicked = false;
            TurretShop.minigunClicked = false;
            TurretShop.missileClicked = false;

            if (GameManager.money >= teslaPrice)
            {

                SpawnTeslaTurret();

                hasTower = true;

            }
            else
            {
                Debug.Log("Not enough money!");
            }

        }

        if (TurretShop.minigunClicked)
        {

            TurretShop.moneyClicked = false;
            TurretShop.voyagerClicked = false;
            TurretShop.teslaClicked = false;
            TurretShop.minigunClicked = false;
            TurretShop.missileClicked = false;

            if (GameManager.money >= minigunPrice)
            {

                SpawnMinigunTurret();

                hasTower = true;

            }
            else
            {
                Debug.Log("Not enough money!");
            }

        }

        if (TurretShop.missileClicked)
        {

            TurretShop.moneyClicked = false;
            TurretShop.voyagerClicked = false;
            TurretShop.teslaClicked = false;
            TurretShop.minigunClicked = false;
            TurretShop.missileClicked = false;

            if (GameManager.money >= missilePrice)
            {

                SpawnMissileTurret();

                hasTower = true;

            }
            else
            {
                Debug.Log("Not enough money!");
            }

        }

    }

    void Start(){

        originalMaterial = mesh.material;

        clickablePanel = GameObject.FindGameObjectWithTag("TurretShop");

        soundManager = FindObjectOfType<SoundManager>();

    }

    public void SpawnMoneyTurret(){

        Debug.Log("Money Turret Spawned");

        GameObject turretInstance = Instantiate(moneyTurretPrefab, transform);

        turretInstance.transform.position = new Vector3(transform.position.x, turretInstance.transform.position.y, transform.position.z);

        GameManager.money -= moneyPrice;

        soundManager.TurretSpawn();

    }

    public void SpawnVoyagerTurret()
    {

        Debug.Log("Voyager Turret Spawned");

        GameObject turretInstance = Instantiate(voyagerTurretPrefab, transform);

        turretInstance.transform.position = new Vector3(transform.position.x, turretInstance.transform.position.y, transform.position.z);

        GameManager.money -= voyagerPrice;

        soundManager.TurretSpawn();

    }

    public void SpawnTeslaTurret()
    {

        Debug.Log("Tesla Turret Spawned");

        GameObject turretInstance = Instantiate(teslaTurretPrefab, transform);

        turretInstance.transform.position = new Vector3(transform.position.x, turretInstance.transform.position.y, transform.position.z);

        GameManager.money -= teslaPrice;

        soundManager.TurretSpawn();

    }

    public void SpawnMinigunTurret()
    {

        Debug.Log("Minigun Turret Spawned");

        GameObject turretInstance = Instantiate(minigunTurretPrefab, transform);

        turretInstance.transform.position = new Vector3(transform.position.x, turretInstance.transform.position.y, transform.position.z);

        GameManager.money -= minigunPrice;

        soundManager.TurretSpawn();

    }

    public void SpawnMissileTurret()
    {

        Debug.Log("Missile Turret Spawned");

        GameObject turretInstance = Instantiate(missileTurretPrefab, transform);

        turretInstance.transform.position = new Vector3(transform.position.x, turretInstance.transform.position.y, transform.position.z);

        GameManager.money -= missilePrice;

        soundManager.TurretSpawn();

    }

}
