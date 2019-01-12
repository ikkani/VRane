using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    public static TutorialManager instance = null;

    public Canvas canvas;
    public Tutorial[] tutoriales;

    public int actualIndex;

    GameObject actualUI;
    int keyIndex;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

   void Start()
    {
        actualIndex = 0;
        keyIndex = 0;
        actualUI = Instantiate(tutoriales[actualIndex].ui,canvas.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(tutoriales[actualIndex].teclas[keyIndex]))
        {
            if (keyIndex == (tutoriales[actualIndex].teclas.Length - 1))
                NextTutorial();
            else
                keyIndex++;
        }
    }

    public void NextTutorial()
    {
        Destroy(actualUI);
        actualIndex++;
        if (actualIndex > (tutoriales.Length - 1))
            SceneManager.LoadScene(0);
        else
        {
            actualUI = Instantiate(tutoriales[actualIndex].ui, canvas.transform);
            keyIndex = 0;
        }

    }
}
