using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerZone : MonoBehaviour {

    bool tutorialActivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Container") && !tutorialActivado)
        {
            TutorialManager.instance.NextTutorial();
            tutorialActivado = true;
        }
    }
}
