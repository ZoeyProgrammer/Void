using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject scoreboardMenu;
    public GameObject skinsMenu;

    private GameObject currentMainMenu;
    private GameObject currentOptionsMenu;
    private GameObject currentScoreboardMenu;
    private GameObject currentSkinsMenu;

    private bool mainMenuActive;
    private bool optionsMenuActive;
    private bool scoreboardMenuActive;
    private bool skinsMenuActive;

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
            OpenMainMenu();
    }

    private void Update()
    {
        if (optionsMenuActive && currentOptionsMenu == null)
        {
            optionsMenuActive = false;
            OpenMainMenu();
        }
        if (scoreboardMenuActive && currentScoreboardMenu == null)
        {
            scoreboardMenuActive = false;
            OpenMainMenu();
        }
        if (skinsMenuActive && currentSkinsMenu == null)
        {
            skinsMenuActive = false;
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

    public void OpenOptions()
    {
        if (currentOptionsMenu == null)
        {
            optionsMenuActive = true;
            currentOptionsMenu = Instantiate(optionsMenu, this.transform);
            Destroy(currentMainMenu);
        }
    }

    public void OpenScoreboard()
    {
        optionsMenuActive = true;
        currentOptionsMenu = Instantiate(scoreboardMenu, this.transform);
        Destroy(currentMainMenu);
    }

    public void OpenSkins()
    {
        optionsMenuActive = true;
        currentOptionsMenu = Instantiate(skinsMenu, this.transform);
        Destroy(currentMainMenu);
    }
}
