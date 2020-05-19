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

    private void Start()
    {
        OpenMainMenu();
    }

    private void Update()
    {
        //Open the Main Menu, when the Options Menu gets closed
        if (optionsMenuActive && currentOptionsMenu == null)
        {
            optionsMenuActive = false;
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
        //Fetch all Score Data
        //Open the Scoreboard Screen
    }

    public void OpenSkins()
    {
        //Open Skins Screen
    }
}
