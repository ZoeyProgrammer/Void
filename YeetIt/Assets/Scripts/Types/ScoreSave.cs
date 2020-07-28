using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSave
{
    public string username;
    public int highscore;
    public int rank;

    public ScoreSave(string username, int highscore, int rank)
    {
        this.username = username;
        this.highscore = highscore;
        this.rank = rank;
    }
}
