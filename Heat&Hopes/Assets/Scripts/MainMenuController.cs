using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public void MainMenuChangeScene(int button) //funcion para el cambio de escena
    {
        switch (button)
        {
            case 0:
                //Cargar escena de juego
                SceneManager.LoadScene("TutorialScene");
                break;
            case 1:
                //Cargar escena de ajustes
                SceneManager.LoadScene("Carlos' Testing Scene");
                break;
            case 2:
                //Cargar escena de accesibilidad
                SceneManager.LoadScene("Dyslexia Test");
                break;
            case 3:
                //Salir
                Application.Quit();
                break;

        }
    }
}
