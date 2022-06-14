using System.Collections.Generic;
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

    private Dictionary<string, GameObject> turretInfos = new Dictionary<string, GameObject>();

    private Dictionary<string, bool> turretsClicked = new Dictionary<string, bool> {
        { "voyager", false },
        { "tesla", false },
        { "money", false },
        { "minigun", false },
        { "missile", false }
    };

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

    }

    public void CancelBuilding(string turretName) => turretsClicked[turretName] = false;

    public void ShowTurretInfo(string turretName) => turretInfos[turretName].SetActive(true);

    public void HideTurretInfo(string turretName) => turretInfos[turretName].SetActive(false);

    public void ClickTurretIcon(string turretName) {

        turretsClicked[turretName] = true;

        cancelBuildingObject.SetActive(true);

    }

}
