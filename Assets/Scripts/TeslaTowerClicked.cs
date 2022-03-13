using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TeslaTowerClicked : MonoBehaviour
{

    public GameObject cancelBuildingObject;

    public GameObject turretInfo;

    public void ShowTurretInfo()
    {

        turretInfo.SetActive(true);

    }

    public void HideTurretInfo()
    {

        turretInfo.SetActive(false);

    }

    public void ClickTurretIcon()
    {

        Debug.Log("Turret Icon Clicked");

        TurretShop.teslaClicked = true;

        cancelBuildingObject.SetActive(true);

    }

    public void UnclickTurretIcon()
    {

        TurretShop.teslaClicked = false;

    }

}
