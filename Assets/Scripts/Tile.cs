using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    [Header("Setup")]

    private Material originalMaterial;
    public Material hoverMaterial;

    public MeshRenderer mesh;

    private bool hasTower = false;


    private void OnMouseEnter(){

        mesh.material = hoverMaterial;
        
    }

    private void OnMouseExit(){

        mesh.material = originalMaterial;
        
    }

    private void OnMouseDown(){

        // Returs if a turret is already placed on the tile
        if (hasTower) return;

        FindObjectOfType<TurretShop>().SpawnTurret(transform);

    }

    void Start(){

        originalMaterial = mesh.material;

    }

}
