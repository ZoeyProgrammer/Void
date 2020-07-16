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

    private void Awake()
    {
        menu = FindObjectOfType<DeathscreenController>();
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        db = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<DBManager>();
    }

    public void UpdateScore()
    {
        if (gm.score >= gm.highscore)
        {
            isNewHighscore = true;
            gm.highscore = gm.score;
            if(gm.isOnline)
                db.SaveHighscore();
            score.text = "New High-Score:" + gm.score.ToString();
        }
        else
        {
            isNewHighscore = false;
            score.text = "Score:" + gm.score.ToString();
        }

        shareButton.SetActive(isNewHighscore);
        scoreButton.SetActive(!isNewHighscore);
    }

    private void ResetScore()
    {
        gm.score = 0;
        gm.timesBounced = 0;
        gm.currHeight = 0;
        gm.height = 0;
    }

    public void ShareButton()
    {
        ResetScore();
        menu.Share();
    }

    public void ScoreButton()
    {
        ResetScore();
        menu.Score();
    }

    public void RetryButton()
    {
        ResetScore();
        menu.Retry();
    }

    public void BackToMenuButton()
    {
        ResetScore();
        menu.BackToMenu();
    }
}
