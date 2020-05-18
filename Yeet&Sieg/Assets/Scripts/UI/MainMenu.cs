using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void OpenOptions()
    {
        //Open the Options Screen
    }

    public void OpenScoreboard()
    {
        //Fetch all Score Data
        //Open the Scoreboard Screen
    }

    public void Skins()
    {
        //Open Skins Screen
    }
}
