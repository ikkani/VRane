using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCar : MonoBehaviour {

    public float velCar;
    int sense;
    public Transform craneBoom;
    Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        sense = (int)Input.GetAxisRaw("Vertical");
        transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z + (sense * velCar * Time.deltaTime));
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

    }

    private void FixedUpdate()
    {
    }
}
