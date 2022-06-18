using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHologram : MonoBehaviour {

    [SerializeField] private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    [SerializeField] private Material buildableMaterial;

    [SerializeField] private Material unbuildableMaterial;

    [SerializeField] private string turretName;

    private string currentMaterial = "buildable";

    void Update() {

        if (currentMaterial != "buildable" && GameManager.money >= FindObjectOfType<TurretShop>().turretPrices[turretName]) {

            ChangeMaterialToBuildable();

        } else if (currentMaterial != "unbuildable" && GameManager.money < FindObjectOfType<TurretShop>().turretPrices[turretName]) {

            ChangeMaterialToUnbuildable();

        }

    }

    private void ChangeMaterialToBuildable() {

        foreach (var mesh in meshRenderers) mesh.material = buildableMaterial;

        currentMaterial = "buildable";

    }

    private void ChangeMaterialToUnbuildable() {

        foreach (var mesh in meshRenderers) mesh.material = unbuildableMaterial;

        currentMaterial = "unbuildable";

    }

}
