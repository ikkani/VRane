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
            dad.GetComponent<Rigidbody>().isKinematic = false;
            Debug.Log("Cepeda calvo");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Container") && Input.GetKeyDown(KeyCode.G) && !agarrado)
        {
            container = other.gameObject.transform;
            dad = container.parent;
            dad.parent = gameObject.transform;
            dad.GetComponent<Rigidbody>().isKinematic = true;
            agarrado = true;
            Debug.Log("Subiendo xd");
            contador = Time.time;
        }
    }
}
