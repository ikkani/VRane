using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiarObjetivo : MonoBehaviour {

    private Vector3 relativePoint;

    float GetSide(Transform objeto){

	relativePoint = transform.InverseTransformPoint(objeto.position);

	return relativePoint.x;

}
}
