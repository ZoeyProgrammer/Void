using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject scoreboardMenu;
    public AudioMixer masterMixer;

    private GameObject currentMainMenu;
    private GameObject currentScoreboardMenu;

    private bool mainMenuActive;
    private bool scoreboardMenuActive;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();

        if (gm.goToScore)
        {
            OpenScoreboard();
            gm.goToScore = false;
        }
        else
        {
            OpenMainMenu();
        }
            
    }

    private void Update()
    {
        if (scoreboardMenuActive && currentScoreboardMenu == null)
        {
            scoreboardMenuActive = false;
            OpenMainMenu();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void OpenMainMenu()
    {
        if (currentMainMenu == null)
        {
            mainMenuActive = true;
            currentMainMenu = Instantiate(mainMenu, this.transform);
        }
    }

    public void OpenScoreboard()
    {
        scoreboardMenuActive = true;
        currentScoreboardMenu = Instantiate(scoreboardMenu, this.transform);
        Destroy(currentMainMenu);
    }

    public void ToggleMusic()
    {
        if (gm.isMusicOn)
        {
            gm.isMusicOn = false;
            masterMixer.SetFloat("musicVolume", -80);
        }
        else
        {
            gm.isMusicOn = true;
            masterMixer.SetFloat("musicVolume", 0);
        }
    }

    public void ToggleSFX()
    {
        if (gm.isSFXOn)
        {
            gm.isSFXOn = false;
            masterMixer.SetFloat("soundVolume", -80);
        }
        else
        {
            gm.isSFXOn = true;
            masterMixer.SetFloat("soundVolume", 0);
        }
    }
}
