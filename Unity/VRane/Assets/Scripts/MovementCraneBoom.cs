using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCraneBoom : MonoBehaviour {

    public float velRotation;
    private int rotCraneBoom;
    private Rigidbody rb;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        rotCraneBoom = (int)Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (rotCraneBoom != 0)
            rb.AddTorque(transform.up * (rotCraneBoom * velRotation));

    }



   }
