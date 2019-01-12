using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour {

    bool space;
    public Camera[] cameras;
    public RenderTexture[] renderTexture;
    public RenderTexture off;
    public Material material;

    int actualIndex;

	// Use this for initialization
	void Start () {
        actualIndex = 0;
        //cameras[actualIndex].targetTexture = renderTexture;
        material.mainTexture = renderTexture[actualIndex];
    }
	
	// Update is called once per frame
	void Update () {
        if (Estados.encendido)
        {
            material.mainTexture = renderTexture[actualIndex];
            space = Input.GetButtonDown("Jump");
            if (space)
            {
                actualIndex = (actualIndex + 1) % renderTexture.Length;
                material.mainTexture = renderTexture[actualIndex];
                //cameras[actualIndex].targetTexture = renderTexture;

            }
        }
        else
        {
            material.mainTexture = off;
        }
	}
}
