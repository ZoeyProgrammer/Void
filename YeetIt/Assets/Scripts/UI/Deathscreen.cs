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
    DBManager db;

    private void Start()
    {
        menu = FindObjectOfType<DeathscreenController>();
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        db = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<DBManager>();

        if (gm.score >= gm.highscore)
        {
            isNewHighscore = true;
            gm.highscore = gm.score;
            db.SaveHighscore();
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
