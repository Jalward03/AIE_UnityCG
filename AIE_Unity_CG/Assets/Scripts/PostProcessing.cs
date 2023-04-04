using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessing : MonoBehaviour
{
    public Material material;
    
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        camera.depthTextureMode = DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_DeltaX", 1.0f / (float)source.width);
        material.SetFloat("_DeltaY", 1.0f / (float)source.height);
        
        Graphics.Blit(source, destination, material);
    }
}
