using System.Collections.Generic;
using UnityEngine;

public class TurretShop : MonoBehaviour{

    public static bool voyagerClicked = false;
    public static bool teslaClicked = false;
    public static bool moneyClicked = false;
    public static bool minigunClicked = false;
    public static bool missileClicked = false;

    public static Dictionary<string, bool> turretsClicked = new Dictionary<string, bool> {
        { "voyager", false },
        { "tesla", false },
        { "money", false },
        { "minigun", false },
        { "missile", false }
    };

    // public static Dictionary<> turretInfos

    public static void CancelBuilding(string turretName) {

        turretsClicked[turretName] = false;

    }

}
