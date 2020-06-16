using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string username;     //Contains the name of the User to ID them

    public int timesBounced;    //Gets Updated after every Bounce
    public int highScore;       //Gets Updated after Death
    public int score;           //Gets Calculated all the time
    public float height;        //Gets Updated everytime the ball enters a Sling
    public float currHeight;    //Gets Updated all the time

    public float musicVolume;
    public float soundVolume;
}
