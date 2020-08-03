using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    MenuController menu;
    GameManager gm;

    public GameObject MusicButtonOn, MusicButtonOff, SFXButtonOn, SFXButtonOFF;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        menu = FindObjectOfType<MenuController>();
        UpdateButtons();
    }

    public void PlayButton()
    {
        menu.StartGame();
    }

    public void ScoreButton()
    {
        menu.OpenScoreboard();
    }

    public void SFXButton()
    {
        menu.ToggleSFX();
        UpdateButtons();
    }

    public void MusicButton()
    {
        menu.ToggleMusic();
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        MusicButtonOn.SetActive(gm.isMusicOn);
        MusicButtonOff.SetActive(!gm.isMusicOn);
        SFXButtonOn.SetActive(gm.isSFXOn);
        SFXButtonOFF.SetActive(!gm.isSFXOn);
    }
}
