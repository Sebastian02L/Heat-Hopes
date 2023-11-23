using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool _gameIsPaused = false;
    private bool _gameInPauseMenu = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_gameIsPaused)
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
        _gameIsPaused = false;
        _gameInPauseMenu = false;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        _gameIsPaused = true;
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
}
