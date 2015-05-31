using UnityEngine;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Pixelate")]
public class PostProcessPixelate : ImageEffectBase
{
    public Texture mask;
    public Vector2 movement;
    [Range(0, 1)]
    public float pixelPower = 0.4f;
    private Vector2 pos;

    void Update()
    {
        pos += movement * Time.deltaTime;
    }

    // Called by camera to apply image effect
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if(pixelPower != 0)
        {
            material.SetTexture("_Pixelate", mask);
            var p = transform.position;
            material.SetTextureOffset("_Pixelate", pos - new Vector2(p.x, p.y) / 10);
            material.SetTextureScale("_Pixelate", new Vector2(Screen.width / Screen.height, 1));
            material.SetFloat("_PixelPower", pixelPower * 0.1f);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}