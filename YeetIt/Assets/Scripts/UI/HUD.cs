using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI scoreCounter;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
    }
    private void Update()
    {
        scoreCounter.text = "Score: " + Mathf.RoundToInt(gm.score);
    }
}
