using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string username;     //Contains the name of the User to ID them
    public string userID;       //Contains the userUI for database purposes
    public List<string> friendList; //Needs to Contain all the ID's for friends, to show their score

    public int timesBounced;    //Gets Updated after every Bounce
    public int highscore;       //Gets Updated after Death
    public int score;           //Gets Calculated all the time
    public float height;        //Gets Updated everytime the ball enters a Sling
    public float currHeight;    //Gets Updated all the time

    public float musicVolume;
    public float soundVolume;

    public bool goToScore;  //For Menu Switching (Yes, I know this is the lazy way..)
    public bool isOnline;  //To check if Auth has worked
}
