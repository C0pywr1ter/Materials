using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialSwapHW : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject  floor;
    Renderer platformRenderer;
    Texture2D texture;
    GameObject button;
    string texturePath;
   
    private void Start()
    {
        walls = GameObject.FindGameObjectsWithTag("Wall");
      

    }
    
    public void ChangeWallTexture(GameObject myButton)
    {
        button = myButton;
        texturePath = button.name;
        Debug.Log(texturePath);
        texture = Resources.Load<Texture2D>(texturePath);
        for(int i = 0; i < walls.Length; i++) 
        {
            platformRenderer = walls[i].GetComponent<Renderer>();
            platformRenderer.material.SetTexture("_MainTex", texture);
       
        }

    
    }
    public void ChangeFloorTexture(GameObject myButton)
    {
        button = myButton;
        texturePath = button.name;
        Debug.Log(texturePath);
        texture = Resources.Load<Texture2D>(texturePath);
       
            platformRenderer = floor.GetComponent<Renderer>();
            platformRenderer.material.SetTexture("_MainTex", texture);

        


    }
}
