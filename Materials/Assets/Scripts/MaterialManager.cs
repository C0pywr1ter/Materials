using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public enum TextureType
    {
        BaseColor = 1,
        Metallic = 3,
        NormalMap
    }


    public GameObject platfrom;
   // public Texture2D texPlatform;


    Renderer platformRenderer;
    //Color32 platformColor = new Color32(0,230,60,255);


    int textureIndex = 0;
    public Texture2D[] textures;
    string[] texturePath = {"Textures/Drought Sand Oiled",
        "Textures/Mud",
        "Textures/Old Cement",
        "Textures/Snow Covered Stone",
        "Textures/Swamp Ground",
        "Textures/Wood Planks"
                           };

    private void Start()
    {
        platformRenderer = platfrom.GetComponent<Renderer>();
       // platformRenderer.material.SetTexture("_MainTex", texPlatform);
        //platformRenderer.material.SetTextureScale("_MainTex", new Vector2(4,4));
       // platformRenderer.material.SetTextureOffset("_MainTex", new Vector2(1.5f, 1));

        //platformRenderer.material.SetTexture("_MainTex", texPlatform);
        //platformRenderer.material.SetColor("_Color", platformColor);
        //platformRenderer.material.SetFloat("_Metallic", 0.7f);

        //platformRenderer.material.EnableKeyword("_EMISSION");
        //platformRenderer.material.SetColor("_EmissionColor", new Color32(0, 110, 130, 255));

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextTexture();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PrevTexture();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangeTextureColor();
        }
    }
    void NextTexture()
    {
        textureIndex = Mathf.Clamp(textureIndex + 1, 0, 5);
        textures = Resources.LoadAll<Texture2D>(texturePath[textureIndex]);

        platformRenderer.material.SetTexture("_MainTex", textures[(int)TextureType.BaseColor]);
        platformRenderer.material.SetTexture("_BumpMap", textures[(int)TextureType.NormalMap]);
        platformRenderer.material.SetTexture("MetallicGlossMap", textures[(int)TextureType.Metallic]);

        platformRenderer.material.SetFloat("_BumpScale", 0.7f);
    }
    void PrevTexture()
    {
        textureIndex = Mathf.Clamp(textureIndex - 1, 0, 5);
        textures = Resources.LoadAll<Texture2D>(texturePath[textureIndex]);

        platformRenderer.material.SetTexture("_MainTex", textures[(int)TextureType.BaseColor]);
        platformRenderer.material.SetTexture("_BumpMap", textures[(int)TextureType.NormalMap]);
        platformRenderer.material.SetTexture("MetallicGlossMap", textures[(int)TextureType.Metallic]);

        platformRenderer.material.SetFloat("_BumpScale", 0.7f);
    }
    void ChangeTextureColor()
    {
        Color randomColor = Random.ColorHSV();
        Color rgbColor = Color.HSVToRGB(randomColor.r, randomColor.g, randomColor.b);

        platformRenderer.material.color = rgbColor;
    }
}
