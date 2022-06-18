using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour{

    private Material originalMaterial;
    public Material hoverMaterial;

    public MeshRenderer mesh;

    [SerializeField] private LayerMask layerMask;

    public bool hasTower { get; set; }

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

    void Start() {

        originalMaterial = mesh.material;

    }

    void Update() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f, layerMask)) {

            Debug.LogError(hit.transform.gameObject.name);
            
            if (hit.transform.gameObject.GetInstanceID() == gameObject.GetInstanceID()) mesh.material = hoverMaterial;

            //hit.transform.gameObject.GetComponent<Tile>().mesh.material = hoverMaterial;

        } else {

            mesh.material = originalMaterial;

        }
        
    }

}
