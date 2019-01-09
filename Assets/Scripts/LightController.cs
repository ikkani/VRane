﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject[] luces;
    public bool on = true;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.L))
        {
            on = !on;
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].SetActive(on);
                }
        }
	}
}
