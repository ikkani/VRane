using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public void OnEmpezarClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSalirClick()
    {
        Application.Quit();
    }
}
