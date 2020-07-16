using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculation : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    private void Update()
    {
        gm.score = Mathf.RoundToInt(gm.height + gm.timesBounced);
    }
}
