﻿using UnityEngine;
using System.Collections;

public class mapDisplay : MonoBehaviour {

    public Renderer textureRender;
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;
    //public MeshCollider meshCollider;

    //GameObject meshObject;

    public void DrawTexture (Texture2D texture) {
        textureRender.sharedMaterial.mainTexture = texture;
        textureRender.transform.localScale = new Vector3(texture.width, 1, texture.height);
    }

    public void DrawMesh (MeshData meshData, Texture2D texture) {
        meshFilter.sharedMesh = meshData.CreateMesh();
        meshRenderer.sharedMaterial.mainTexture = texture;

        //meshObject = new GameObject("Terrain Chunk");
        //meshCollider = meshObject.AddComponent<MeshCollider>();
    }
   

}
