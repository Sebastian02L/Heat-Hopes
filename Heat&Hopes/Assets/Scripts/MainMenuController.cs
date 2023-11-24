using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject loadOverlay;
    public Image loadBar;
    private bool loading;

    private void Start()
    {
        loadOverlay.SetActive(false);
    }

    public void MainMenuChangeScene(int button) //funcion para el cambio de escena
    {
        switch (button)
        {
            case 0:
                //Cargar escena de juego
                if (!loading)
                {
                    StartCoroutine(LoadNextScene());
                    loading = true;
                    loadOverlay.SetActive(true);
                }
                break;
            case 1:
                //Cargar escena de ajustes, debería ser una parte del canvas
                SceneManager.LoadScene("Carlos' Testing Scene");
                break;
            case 2:
                //Cargar escena de accesibilidad, debería ser una parte del canvas
                SceneManager.LoadScene("Dyslexia Test");
                break;
            case 3:
                //Salir
                Application.Quit();
                break;

        }
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync("TutorialScene");

        while (!loadLevel.isDone) 
        {
            loadBar.fillAmount = Mathf.Clamp01(loadLevel.progress / 0.9f);
            yield return null;
        }
    }
}
