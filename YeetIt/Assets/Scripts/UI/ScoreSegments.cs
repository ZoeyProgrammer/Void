using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSegments : MonoBehaviour
{
    public ScoreSave scoreSave;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI rankText;

    private void Start()
    {
        nameText.text = "Name: " + scoreSave.username;
        highscoreText.text = "Highscore: " + scoreSave.highscore;
        rankText.text = "#" + scoreSave.rank;
    }
}
