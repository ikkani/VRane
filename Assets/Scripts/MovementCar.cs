using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour {

    public float velocidad = 0.5f;

    private float temp = 0;
    private float oldTemp = 0;

    void FixedUpdate()
    {
        if (Estados.encendido)
        {
            temp = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;

            oldTemp = temp;

            if (transform.localPosition.z > 16.5f || transform.localPosition.z < 2)
                temp *= 0.5f;
            if (transform.localPosition.z + temp < 1.4 || transform.localPosition.z + temp > 17.3)
                temp = 0;

            transform.localPosition += new Vector3(0, 0, temp);
        }
    }
}
