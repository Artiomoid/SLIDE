using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostEffectController : MonoBehaviour
{
    public Shader postShader;
    Material postEffectmaterial;


    void OnRenderImage(RenderTexture src, RenderTexture dest) {

        if(postEffectmaterial == null){
            postEffectmaterial = new Material(postShader);
        }

       RenderTexture renderTexture = RenderTexture.GetTemporary(
        src.width,
        src.height,
        0,
        src.format);
        Graphics.Blit(src, renderTexture, postEffectmaterial);
        Graphics.Blit(renderTexture, dest);
        
        RenderTexture.ReleaseTemporary(renderTexture);
    }
}
