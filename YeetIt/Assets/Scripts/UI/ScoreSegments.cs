using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSegments : MonoBehaviour
{
    public string username = "[Not Assigned]";
    public int highscore = 0;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        nameText.text = "Name: " + username;
        highscoreText.text = "Highscore: " + highscore;
    }
}
