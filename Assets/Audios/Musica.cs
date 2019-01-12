using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour {

    AudioSource audioSource;
    bool isPlaying;

	// Use this for initialization
	void Start () {
        isPlaying = false;
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
            else
            {
                audioSource.Pause();
                isPlaying = false;
            }
        }

    }
}
