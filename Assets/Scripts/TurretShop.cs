using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurretShop : MonoBehaviour {

    // I had to create a serialized array and put the values from it to the dictionary because unity is retarded and can't serialize a dictionary
    [SerializeField] private GameObject[] turretInfosArray;
    [SerializeField] private GameObject[] turretButtonsArray;
    [SerializeField] private GameObject[] turretPrefabsArray;

    private Dictionary<string, GameObject> turretInfos = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> turretButtons = new Dictionary<string, GameObject>();
    public Dictionary<string, GameObject> turretPrefabs = new Dictionary<string, GameObject>();

    public Dictionary<string, bool> turretsClicked = new Dictionary<string, bool> {
        { "voyager", false },
        { "tesla", false },
        { "money", false },
        { "minigun", false },
        { "missile", false }
    };

    private Dictionary<string, int> turretPrices = new Dictionary<string, int> {
        { "voyager", 50 },
        { "tesla", 100 },
        { "money", 125 },
        { "minigun", 175 },
        { "missile", 250 }
    };

    [SerializeField] private Color turretPressedColor;
    [SerializeField] private Color turretNotPressedColor;

    private void Start() {

        if (turretInfosArray.Length != 5 || turretButtonsArray.Length != 5 || turretPrefabsArray.Length != 5) {
            
            Debug.LogError("Not all items added to arrays in unity inspector!");
            return;

        }

        turretInfos.Add("voyager", turretInfosArray[0]);
        turretInfos.Add("tesla", turretInfosArray[1]);
        turretInfos.Add("money", turretInfosArray[2]);
        turretInfos.Add("minigun", turretInfosArray[3]);
        turretInfos.Add("missile", turretInfosArray[4]);

        turretButtons.Add("voyager", turretButtonsArray[0]);
        turretButtons.Add("tesla", turretButtonsArray[1]);
        turretButtons.Add("money", turretButtonsArray[2]);
        turretButtons.Add("minigun", turretButtonsArray[3]);
        turretButtons.Add("missile", turretButtonsArray[4]);

        turretPrefabs.Add("voyager", turretPrefabsArray[0]);
        turretPrefabs.Add("tesla", turretPrefabsArray[1]);
        turretPrefabs.Add("money", turretPrefabsArray[2]);
        turretPrefabs.Add("minigun", turretPrefabsArray[3]);
        turretPrefabs.Add("missile", turretPrefabsArray[4]);

    }

    public void ShowTurretInfo(string turretName) => turretInfos[turretName].SetActive(true);

    public void HideTurretInfo(string turretName) => turretInfos[turretName].SetActive(false);

    public void ClickTurretIcon(string turretName) {

        // Unselects every other turret button
        foreach (string turret in turretButtons.Keys) {

            if (turretName != turret) {
                
                turretsClicked[turret] = false;

                var buttonColors = turretButtons[turret].GetComponent<Button>().colors;

                buttonColors.normalColor = turretNotPressedColor;
                buttonColors.highlightedColor = turretNotPressedColor;
                buttonColors.pressedColor = turretNotPressedColor;
                buttonColors.selectedColor = turretNotPressedColor;
                buttonColors.disabledColor = turretNotPressedColor;

                turretButtons[turret].GetComponent<Button>().colors = buttonColors;

            }

        }

        var colors = turretButtons[turretName].GetComponent<Button>().colors;

        if (turretsClicked[turretName]) {

            colors.normalColor = turretNotPressedColor;
            colors.highlightedColor = turretNotPressedColor;
            colors.pressedColor = turretNotPressedColor;
            colors.selectedColor = turretNotPressedColor;
            colors.disabledColor = turretNotPressedColor;

            turretsClicked[turretName] = false;

        } else {

            colors.normalColor = turretPressedColor;
            colors.highlightedColor = turretPressedColor;
            colors.pressedColor = turretPressedColor;
            colors.selectedColor = turretPressedColor;
            colors.disabledColor = turretPressedColor;

            turretsClicked[turretName] = true;

        }

        turretButtons[turretName].GetComponent<Button>().colors = colors;

    }

    public string GetSelectedTurret(out bool anyTurretSelected) {

        foreach (KeyValuePair<string, bool> item in turretsClicked) {

            if (item.Value) {
             
                anyTurretSelected = true;
                return item.Key;
            
            }
        }

        anyTurretSelected = false;
        return string.Empty;

    }

    

    public void SpawnTurret(Transform tile) {

        // Returs if a turret is already placed on the tile
        if (tile.gameObject.GetComponent<Tile>().hasTower) return;

        string turretName = GetSelectedTurret(out bool turretSelected);

        if (!turretSelected) {

            Debug.LogError("No turret selected!");
            return;

        }

        var turretInstance = Instantiate(turretPrefabs[turretName], tile);

        turretInstance.transform.position = new Vector3(tile.position.x, turretInstance.transform.position.y, tile.position.z);

        turretInstance.GetComponent<TowerHealth>().tile = tile.GetComponent<Tile>();

        GameManager.money -= turretPrices[turretName];

        FindObjectOfType<SoundManager>().TurretSpawn();

        tile.gameObject.GetComponent<Tile>().hasTower = true;

    }

}
