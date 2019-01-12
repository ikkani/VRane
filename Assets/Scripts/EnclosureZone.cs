using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnclosureZone : MonoBehaviour {

    bool tutorialActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Container") && !tutorialActivado)
        {
            Debug.Log("Enclosure");
            TutorialManager.instance.NextTutorial();
            tutorialActivado = true;
            
        }
    }
}
