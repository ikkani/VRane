using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameras : MonoBehaviour {

    bool space;
    public Camera[] cameras;
    public RenderTexture[] renderTexture;
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
        space = Input.GetButtonDown("Jump");
        if(space)
        {
            actualIndex = (actualIndex + 1) % renderTexture.Length;
            material.mainTexture = renderTexture[actualIndex]; 
            //cameras[actualIndex].targetTexture = renderTexture;

        }
	}
}
