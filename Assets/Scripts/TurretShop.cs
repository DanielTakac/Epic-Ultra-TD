using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurretShop : MonoBehaviour {

    public static bool voyagerClicked = false;
    public static bool teslaClicked = false;
    public static bool moneyClicked = false;
    public static bool minigunClicked = false;
    public static bool missileClicked = false;

    [SerializeField] private GameObject cancelBuildingObject;

    // I had to create a serialized array and put the values from it to the dictionary because unity is retarded and can't serialize a dictionary
    [SerializeField] private GameObject[] turretInfosArray;
    [SerializeField] private GameObject[] turretButtonsArray;

    private Dictionary<string, GameObject> turretInfos = new Dictionary<string, GameObject>();
    private Dictionary<string, GameObject> turretButtons = new Dictionary<string, GameObject>();

    private Dictionary<string, bool> turretsClicked = new Dictionary<string, bool> {
        { "voyager", false },
        { "tesla", false },
        { "money", false },
        { "minigun", false },
        { "missile", false }
    };

    [SerializeField] private Color turretPressedColor;
    [SerializeField] private Color turretNotPressedColor;

    private void Start() {

        if (turretInfosArray.Length != 5) {
            
            Debug.LogError("Not all turret infos added to turretInfosArray!");
            return;

        }

        turretInfos.Add("voyager", turretInfosArray[0]);
        turretInfos.Add("tesla", turretInfosArray[1]);
        turretInfos.Add("money", turretInfosArray[2]);
        turretInfos.Add("minigun", turretInfosArray[3]);
        turretInfos.Add("missile", turretInfosArray[4]);

        if (turretButtonsArray.Length != 5) {

            Debug.LogError("Not all turret buttons added to turretButtonsArray!");
            return;

        }

        turretButtons.Add("voyager", turretButtonsArray[0]);
        turretButtons.Add("tesla", turretButtonsArray[1]);
        turretButtons.Add("money", turretButtonsArray[2]);
        turretButtons.Add("minigun", turretButtonsArray[3]);
        turretButtons.Add("missile", turretButtonsArray[4]);

        cancelBuildingObject.SetActive(false);

    }

    public void CancelBuilding(string turretName) => turretsClicked[turretName] = false;

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

            cancelBuildingObject.SetActive(false);

            Debug.LogError(turretName + " unselected");

        } else {

            colors.normalColor = turretPressedColor;
            colors.highlightedColor = turretPressedColor;
            colors.pressedColor = turretPressedColor;
            colors.selectedColor = turretPressedColor;
            colors.disabledColor = turretPressedColor;

            turretsClicked[turretName] = true;

            cancelBuildingObject.SetActive(true);

            Debug.LogError(turretName + " selected");

        }

        turretButtons[turretName].GetComponent<Button>().colors = colors;

    }

}
