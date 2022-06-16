using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class provides all basic functions of a turret boost and is inherited in all boost classes

public abstract class TurretBoost : MonoBehaviour {

    [SerializeField] protected List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

    protected List<Material> originalMaterials = new List<Material>();

    [SerializeField] protected Material hoverMat;

    protected Texture2D whiteCursor;

    protected SoundManager soundManager;

    protected bool activated = false;

    protected void OnMouseEnter() {

        if (BoostShop.boostSelected) {

            foreach (MeshRenderer mesh in meshRenderers) mesh.material = hoverMat;

        }

    }

    protected void OnMouseExit() {

        if (BoostShop.boostSelected) {

            for (int i = 0; i < meshRenderers.Count; i++) meshRenderers[i].material = originalMaterials[i];

        }

    }

    protected void OnMouseDown() {

        Cursor.SetCursor(whiteCursor, Vector2.zero, CursorMode.ForceSoftware);

        if (BoostShop.boostSelected && activated == false) {

            for (int i = 0; i < meshRenderers.Count; i++) meshRenderers[i].material = originalMaterials[i];

            BoostShop.boostSelected = false;

            BoostShop.boosts--;

            Activate();

        }

    }

    protected void Start() {

        originalMaterials = new List<Material>();

        for (int i = 0; i < meshRenderers.Count; i++) originalMaterials.Add(meshRenderers[i].material);

        soundManager = FindObjectOfType<SoundManager>();

        // Debug.LogError("Original materials: " + originalMaterials.Count);
        // Debug.LogError("Mesh renderers: " + meshRenderers.Count);

    }

    public abstract void Activate();

}
