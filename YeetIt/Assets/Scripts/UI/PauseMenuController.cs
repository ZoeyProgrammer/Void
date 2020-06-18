using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject optionsMenu;


    private GameObject currentPauseMenu;
    private GameObject currentOptionsMenu;

    private bool optionsMenuActive;


    private void Update()
    {
        if (optionsMenuActive && currentOptionsMenu == null)
        {
            optionsMenuActive = false;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (currentPauseMenu == null)
        {
            currentPauseMenu = Instantiate(pauseMenu, this.transform);
            Time.timeScale = 0;
        }
    }

    public void ResumeGame()
    {
        if (currentPauseMenu != null)
        {
            Destroy(currentPauseMenu);
            Time.timeScale = 1;
        }
    }

    public void OpenOptions()
    {
        if (currentOptionsMenu == null)
        {
            optionsMenuActive = true;
            currentOptionsMenu = Instantiate(optionsMenu, this.transform);
            Destroy(currentPauseMenu);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
