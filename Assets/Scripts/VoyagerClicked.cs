using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VoyagerClicked : MonoBehaviour{

    public GameObject cancelBuildingObject;

    public GameObject turretInfo;

    public void ShowTurretInfo(){

        turretInfo.SetActive(true);

    }

    public void HideTurretInfo(){

        turretInfo.SetActive(false);

    }

    public void ClickTurretIcon(){

        Debug.Log("Turret Icon Clicked");

        TurretShop.voyagerClicked = true;

        cancelBuildingObject.SetActive(true);

    }

    public void UnclickTurretIcon(){

        TurretShop.voyagerClicked = false;

    }

}
