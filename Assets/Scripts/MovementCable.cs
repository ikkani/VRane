using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCable : MonoBehaviour
{

    // Script del cable principal TROZODECABLE1, con la propiedad 'is Kinematic' asignada,
    // encargado de la elevación

    public AudioSource SonidoCable;

    //Velocidad de elevación
    public float velocidad = 0.05f;

    //Suavidad
    public float aceleracion = 0.01f;

    //prefab del modelo a crear "trozo de cable"
    public GameObject prefab;

    public Transform Malla;
    public Transform[] Huesos;


    //Componente Joint del trozo de cable unido al gancho
    public GameObject Pivote;
    public FixedJoint CableFinal;


    private int nElemento = 0; //Indice del número trozos de cable creados
    private GameObject[] nGameObject; //Matriz de elementos que guarda los trozos de cable creados
    private Vector3 posInicial; //Para guardar las posicion inicial LOCAL
    private FixedJoint tempFixedJoint; //Para guardar un Fixed Joint
    private FixedJoint temp2FixedJoint; //Para guardar un Fixed Joint
    private Rigidbody tempRigidBody; //Para guardar un RigidBody y asignarlo a un Fixed Joint

    private float limSuperior;
    private float limInferior;

    public static float temp = 0.0f;


    int GetnElemento()
    {
        return nElemento;
    }

    float GetlimSuperior()
    {
        return limSuperior;
    }

    void Start()
    {

        limSuperior = transform.localPosition.y;
        limInferior = limSuperior - 0.55f;

        nGameObject = new GameObject[35]; //Creamos la matriz
        nGameObject[0] = CableFinal.gameObject;
        nGameObject[34] = Pivote;

        posInicial = new Vector3(); //Creamos el Vector3
        posInicial = transform.localPosition; //Guardamos la posición inicial LOCAL (utilizada en objectos children/hijos)

        SonidoCable.volume=0;	


    }

    void Update()
    { //Función del sistema procesos antes del renderizado

        if (Estados.encendido)
        {
            Malla.rotation = Pivote.transform.rotation;

            for (int i = 0; i < 35; i++)
            {
                if ((i > nElemento) && (Huesos[i].position != Pivote.transform.position)) Huesos[i].position = Pivote.transform.position;
                else if ((i <= nElemento) && (Huesos[i].position != nGameObject[i].transform.position)) Huesos[i].position = nGameObject[i].transform.position;
            }
        }

    }

    void FixedUpdate()
    { //Función del sistema para Físicas

        if (Estados.encendido)
        {
            //La Elevación del cable funciona pulsando las teclas Z-X
            if (Input.GetKey(KeyCode.Z)) temp = Mathf.Clamp(temp + aceleracion * Time.deltaTime, -velocidad, velocidad);
            else if (Input.GetKey(KeyCode.X)) temp = Mathf.Clamp(temp - aceleracion * Time.deltaTime, -velocidad, velocidad);
            else if (temp > 0) temp = Mathf.Clamp(temp - aceleracion * Time.deltaTime * 3, 0, temp);
            else temp = Mathf.Clamp(temp + aceleracion * Time.deltaTime * 3, temp, 0);


            //Limitar velocidad elevación a la mitad cuando estemos cerca de límite de rango
            if ((temp < 0) && (nElemento == 33)) temp *= 0.5f;
            if ((temp > 0) && (nElemento == 0)) temp *= 0.5f; //34 eslabones(indice 33) + 1 fijo

            //Evitar crear índices fuera de rango [0-27]
            if ((transform.localPosition.y + temp > limSuperior) && (nElemento == 0)) temp = 0.0f;
            if ((transform.localPosition.y + temp < limInferior) && (nElemento == 33)) temp = 0.0f; //34 eslabones(indice 33) + 1 fijo	

            SonidoCable.volume = Mathf.Clamp(Mathf.Abs(temp) * 2, 0, 1);


            //Destruimos trozo de cable cuando nuestra posición LOCAL está por encima del límite superior
            if (transform.localPosition.y + temp > limSuperior)
            {

                if (nElemento == 1)
                { //Solo existe un trozo de cable creado

                    transform.position = new Vector3(transform.position.x, nGameObject[1].transform.position.y, transform.position.z);
                    limInferior = transform.localPosition.y;
                    Destroy(nGameObject[1]);
                    CableFinal.connectedBody = GetComponent<Rigidbody>(); //conectar Fixed Joint del Cable unido al gancho con este objeto

                }
                else
                {

                    transform.position = new Vector3(transform.position.x, nGameObject[nElemento].transform.position.y, transform.position.z);
                    limInferior = transform.localPosition.y;
                    Destroy(nGameObject[nElemento]);


                    tempFixedJoint = nGameObject[nElemento - 1].GetComponent<FixedJoint>(); //Conectar al trozo de cable anterior
                    tempFixedJoint.connectedBody = GetComponent<Rigidbody>();

                }

                nElemento -= 1;

            }

            //Creamos trozo de cable cuando nuestra posición LOCAL está por debajo de -0.64	
            if (transform.localPosition.y + temp < limInferior)
            {

                nElemento += 1;

                if (nElemento == 1)
                { //No existe ningún trozo de cable creado

                    nGameObject[nElemento] = Instantiate(prefab, transform.position, transform.rotation); //Creamos nuevo trozo de cable
                    tempRigidBody = nGameObject[nElemento].GetComponent<Rigidbody>();
                    tempFixedJoint = nGameObject[nElemento].GetComponent<FixedJoint>();
                    CableFinal.connectedBody = tempRigidBody;   //Conectamos el Cable unido al gancho con el nuevo trozo de cable creado		
                    transform.localPosition += new Vector3(0, 0.55f, 0);
                    limSuperior = transform.localPosition.y;
                    tempFixedJoint.connectedBody = GetComponent<Rigidbody>(); //Conectamos el nuevo trozo de cable creado a este objeto
                }
                else
                {

                    nGameObject[nElemento] = Instantiate(prefab, transform.position, transform.rotation); //Creamos nuevo trozo de cable
                    tempRigidBody = nGameObject[nElemento].GetComponent<Rigidbody>();
                    tempFixedJoint = nGameObject[nElemento].GetComponent<FixedJoint>();
                    temp2FixedJoint = nGameObject[nElemento - 1].GetComponent<FixedJoint>();
                    temp2FixedJoint.connectedBody = tempRigidBody; //Unimos el trozo de cable anterior al nuevo trozo de cable			
                    transform.localPosition += new Vector3(0, 0.55f, 0);
                    limSuperior = transform.localPosition.y;
                    tempFixedJoint.connectedBody = GetComponent<Rigidbody>(); //Unimos el nuevo trozo de cable a este objeto

                }

            }

            //Elevar objeto
            transform.Translate(new Vector3(0, temp, 0));


        }
    }
}