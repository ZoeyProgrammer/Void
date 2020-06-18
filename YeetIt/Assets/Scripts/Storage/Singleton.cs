using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    static GameObject instance;

    void Awake()
    {
        //check that it exisits
        if (instance == null)
        {
            //Assign it to the current object
            instance = this.gameObject;
        }

        //Make sure that it is equal to the current object
        else if (instance != this.gameObject)
        {
            //Destroy the Object if we already have one, because we only need 1
            Destroy(gameObject);
        }

        //Dont destroy the Singleton Object when changing Scenes
        DontDestroyOnLoad(gameObject);
    }
}
