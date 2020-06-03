using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI bounceCounter;
    public TextMeshProUGUI scoreCounter;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
    }
    private void Update()
    {
        bounceCounter.text = "Times Bounced: " + gm.timesBounced;
        scoreCounter.text = "Height: " + Mathf.RoundToInt(gm.height);
    }
}
