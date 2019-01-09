using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerPhysics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Container"))
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Container"))
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
    }
}
