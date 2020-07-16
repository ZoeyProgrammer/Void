using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathscreenController : MonoBehaviour
{
    public GameObject deathscreen;
    public GameObject scorescreen;

    private GameObject currentDeathscreen;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
    }

    public void OpenDeathscreen()
    {
        if (currentDeathscreen == null)
        {
            currentDeathscreen = Instantiate(deathscreen, this.transform);
            currentDeathscreen.GetComponent<Deathscreen>().UpdateScore();
            Time.timeScale = 0;
        }
    }

    public void Score()
    {
        Time.timeScale = 1;
        gm.goToScore = true;
        SceneManager.LoadSceneAsync("MainMenu");
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
