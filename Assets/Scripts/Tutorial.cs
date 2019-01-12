using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Items/Tutorial", order = 1)]
public class Tutorial : ScriptableObject {

    public GameObject ui;
    public KeyCode[] teclas;
}
