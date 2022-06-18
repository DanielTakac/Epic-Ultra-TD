using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    [Header("Setup")]

    private Material originalMaterial;
    public Material hoverMaterial;

    public MeshRenderer mesh;

    public bool hasTower { get; set; }

    private void OnMouseEnter(){

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

    }

    void Start(){

        originalMaterial = mesh.material;

    }

}
