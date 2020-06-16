using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    MenuController menu;

    private void Start()
    {
        menu = FindObjectOfType<MenuController>();
    }

    public void PlayButton()
    {
        menu.StartGame();
    }

    public void ScoreButton()
    {
        menu.OpenScoreboard();
    }

    public void OptionsButton()
    {
        menu.OpenOptions();
    }

    public void SkinsButton()
    {
        menu.OpenSkins();
    }
}
