using UnityEngine;

public class CancelBuilding : MonoBehaviour{

    public void CancelBuildingFunction(){

        TurretShop.voyagerClicked = false;
        TurretShop.moneyClicked = false;
        TurretShop.teslaClicked = false;
        TurretShop.minigunClicked = false;
        TurretShop.missileClicked = false;

        Debug.Log("Building Cancelled");

    }

}
