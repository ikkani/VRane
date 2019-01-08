using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour {

    public float time = 5;
    public float aceleracion = 0.1f;
    public float velocidad  = 0.1f;
	
	// Update is called once per frame
	void Update () {
		if(Time.time < time)
        {
            MovementCable.temp = Mathf.Clamp(MovementCable.temp - aceleracion * Time.deltaTime, -velocidad, velocidad);
        }
        else {
            Destroy(gameObject);
        }
	}
}
