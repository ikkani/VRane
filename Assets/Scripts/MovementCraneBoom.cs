using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCraneBoom : MonoBehaviour {

    public float velocidad = 10;

    private void FixedUpdate()
    {
        if (Estados.encendido)
        {
            transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * Time.deltaTime * velocidad, 0));
        }
    }
}
