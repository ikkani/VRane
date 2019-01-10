using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerGrabbing : MonoBehaviour {

    bool agarrado = false;
    Transform container;
    Transform dad;
    float contador;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (agarrado && Input.GetKeyDown(KeyCode.G) && Time.time >= (contador+1))
        {
            dad.parent = null;
            agarrado = false;
            dad.GetComponent<Rigidbody>().useGravity = true;
            dad.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            dad.GetComponent<Rigidbody>().mass = 10000;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Container") && Input.GetKeyDown(KeyCode.G) && !agarrado)
        {
            container = other.gameObject.transform;
            dad = container.parent;
            dad.parent = gameObject.transform;
            dad.GetComponent<Rigidbody>().useGravity = false;
            dad.GetComponent<Rigidbody>().mass = 1;
            dad.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            agarrado = true;
            contador = Time.time;
        }
    }
}
