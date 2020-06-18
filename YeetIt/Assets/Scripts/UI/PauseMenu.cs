using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    PauseMenuController menu;

    private void Start()
    {
        menu = FindObjectOfType<PauseMenuController>();
    }

    public void ResumeButton()
    {
        menu.ResumeGame();
    }

    public void OptionsButton()
    {
        menu.OpenOptions();
    }

    public void RestartButton()
    {
        menu.RestartGame();
    }

    public void BackToMenuButton()
    {
        menu.BackToMenu();
    }
}
