using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject[] luces;
    public Animator animator;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.L))
        {
            audioSource.Play();
            animator.SetBool("ON", !animator.GetBool("ON"));
                for (int i = 0; i < luces.Length; i++)
                {
                    luces[i].SetActive(animator.GetBool("ON"));
                }
        }
	}
}
