using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    public MeshRenderer mesh;

    public bool hasTower { get; set; }
    public bool hasHologram { get; set; }

    /*private void OnMouseEnter(){

        FindObjectOfType<TurretShop>().GetSelectedTurret(out bool turretSelected);

        if (turretSelected && !hasTower) {

            mesh.material = hoverMaterial;

            FindObjectOfType<TurretShop>().SpawnTurretHologram(transform);

        }
        
    }

    private void OnMouseExit(){

        mesh.material = originalMaterial;

        var holograms = FindObjectsOfType<TurretHologram>();

        foreach (var hologram in holograms) Destroy(hologram.gameObject);
        
    }

    private void OnMouseDown(){

        FindObjectOfType<TurretShop>().SpawnTurret(transform);

    }*/

}
