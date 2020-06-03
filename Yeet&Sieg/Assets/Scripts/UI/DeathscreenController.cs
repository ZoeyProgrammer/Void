using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathscreenController : MonoBehaviour
{
    public GameObject deathscreen;

    private GameObject currentDeathscreen;

    public void OpenDeathscreen()
    {
        if (currentDeathscreen == null)
        {
            currentDeathscreen = Instantiate(deathscreen, this.transform);
            Time.timeScale = 0;
        }
    }

    public void Score()
    {
        //Time.timeScale = 1;
        //Open the Score Scene
        Debug.Log("Not yet Implemented");
    }

    public void Share()
    {
        //Time.timeScale = 1;
        //Good Question how to do dis
        Debug.Log("Not yet Implemented");
    }

    public void Retry()
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
