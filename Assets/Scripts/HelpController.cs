using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpController : MonoBehaviour
{
    bool tutorialActivado = false;
    bool tutorialSiguiente = false;

    public Collider collider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Imán"))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            collider.enabled = false;
            if (!tutorialActivado)
            {
                TutorialManager.instance.NextTutorial();
                tutorialActivado = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(Estados.agarrando && !tutorialSiguiente)
        {
            TutorialManager.instance.NextTutorial();
            tutorialSiguiente = true;
            Debug.Log("Help");
        }
    }
}