using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encender : MonoBehaviour {

    public GameObject magia;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!Estados.encendido)
                ON();
            else
                OFF();

        }
    }

    public void ON()
    {
        if(magia != null)
            magia.SetActive(true);

        Estados.encendido = true;
    }

    public void OFF()
    {
        Estados.encendido = false;
    }
}
