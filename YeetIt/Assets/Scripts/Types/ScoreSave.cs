using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave
{
    public string username;
    public int highscore;

    public ScoreSave(string username, int highscore)
    {
        this.username = username;
        this.highscore = highscore;
    }
}
