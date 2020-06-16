using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Deathscreen : MonoBehaviour
{
    public TextMeshProUGUI score;
    public GameObject shareButton;
    public GameObject scoreButton;

    private bool isNewHighscore;

    DeathscreenController menu;
    GameManager gm;

    private void Start()
    {
        menu = FindObjectOfType<DeathscreenController>();
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();

        gm.score = Mathf.RoundToInt(gm.height);//For now, until there is proper score calculation

        if (gm.score >= gm.highScore)
        {
            isNewHighscore = true;
            gm.highScore = gm.score;
        }
        else
            isNewHighscore = false;

        shareButton.SetActive(isNewHighscore);
        scoreButton.SetActive(!isNewHighscore);
        score.text = "Score:" + gm.score.ToString();

        gm.score = 0;
        gm.timesBounced = 0;
        gm.currHeight = 0;
        gm.height = 0;
    }

    public void ShareButton()
    {
        menu.Share();
    }

    public void ScoreButton()
    {
        menu.Score();
    }

    public void RetryButton()
    {
        menu.Retry();
    }

    public void BackToMenuButton()
    {
        menu.BackToMenu();
    }
}
