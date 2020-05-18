using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePause = false;
    public GameObject pauseMenuUI;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // to freeze the game's time when click Esc button
        isGamePause = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f; // to stop pausing game
        SceneManager.LoadScene("MenuGame");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
