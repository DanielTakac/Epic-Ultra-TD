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

        mesh.material = hoverMaterial;
        
    }

    private void OnMouseExit(){

        mesh.material = originalMaterial;
        
    }

    private void OnMouseDown(){

        FindObjectOfType<TurretShop>().SpawnTurret(transform);

    }

    void Start(){

        originalMaterial = mesh.material;

    }

}
