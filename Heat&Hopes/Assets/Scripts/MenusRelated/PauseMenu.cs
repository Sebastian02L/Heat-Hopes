using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool shopIsOpen = false; //Indica que la tienda está abierta para restringir el menú de pausa
    public bool confirmationEnabled = true; //Indica si las confirmaciones están activadas o no
                                            //Se pone en este script para que sea más fácil acceder a él desde la tienda y puertas
    [SerializeField] private GameObject confirmationEnabledButton;
    [SerializeField] private GameObject confirmationDisabledButton;

    private bool _gameInPauseMenu = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !shopIsOpen)
        {
            if (gameIsPaused)
            {
                if (_gameInPauseMenu)
                {
                    Resume();
                }
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gameIsPaused = false;
        _gameInPauseMenu = false;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gameIsPaused = true;
        _gameInPauseMenu = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Debug.Log("Closing Application...");
        Application.Quit();
    }

    public void changePauseMenuStatus()
    {
        _gameInPauseMenu = !_gameInPauseMenu;
    }

    public void ToggleConfirmation()
    {
        confirmationEnabled = !confirmationEnabled;
        if (confirmationEnabled)
        {
            confirmationEnabledButton.SetActive(true);
            confirmationDisabledButton.SetActive(false);
        }
        else
        {
            confirmationEnabledButton.SetActive(false);
            confirmationDisabledButton.SetActive(true);
        }
    }
}
