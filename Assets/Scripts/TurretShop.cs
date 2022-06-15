using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurretShop : MonoBehaviour {

    [SerializeField] private Transform test;

    // I had to create a serialized array and put the values from it to the dictionary because unity is retarded and can't serialize a dictionary
    [SerializeField] private GameObject[] turretInfosArray;
    [SerializeField] private GameObject[] turretButtonsArray;
    [SerializeField] private GameObject[] turretPrefabsArray;

    private Dictionary<string, GameObject> turretInfos = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> turretButtons = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> turretPrefabs = new Dictionary<string, GameObject>();

    private Dictionary<string, bool> turretsClicked = new Dictionary<string, bool> {
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

        // TEST

        turretsClicked["minigun"] = true;

        foreach (Transform child in test) SpawnTurret(child);

        // TEST

    }

    public void ShowTurretInfo(string turretName) => turretInfos[turretName].SetActive(true);

    public void HideTurretInfo(string turretName) => turretInfos[turretName].SetActive(false);

    public void ClickTurretIcon(string turretName) {

        // Return if another turret is already selected
        foreach (KeyValuePair<string, bool> turretClicked in turretsClicked) {

            if (turretClicked.Value && turretClicked.Key != turretName) {

                Debug.LogError("Another turret already selected");

                return;

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

            Debug.LogError(turretName + " unselected");

        } else {

            colors.normalColor = turretPressedColor;
            colors.highlightedColor = turretPressedColor;
            colors.pressedColor = turretPressedColor;
            colors.selectedColor = turretPressedColor;
            colors.disabledColor = turretPressedColor;

            turretsClicked[turretName] = true;

            Debug.LogError(turretName + " selected");

        }

        turretButtons[turretName].GetComponent<Button>().colors = colors;

    }

    private string GetSelectedTurret() {

        foreach (KeyValuePair<string, bool> item in turretsClicked) {

            if (item.Value) return item.Key;

        }

        return string.Empty;

    }

    public void SpawnTurret(Transform tile) {

        string turretName = GetSelectedTurret();

        if (turretName == string.Empty) {

            Debug.LogError("No turret selected!");
            return;

        }

        var turretInstance = Instantiate(turretPrefabs[turretName], tile);

        turretInstance.transform.position = new Vector3(tile.position.x, turretInstance.transform.position.y, tile.position.z);

        GameManager.money -= turretPrices[turretName];

        FindObjectOfType<SoundManager>().TurretSpawn();

    }

}
