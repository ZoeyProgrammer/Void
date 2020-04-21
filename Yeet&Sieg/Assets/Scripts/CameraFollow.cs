﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag(Tags.ball);
    }

    private void Update()
    {
        if (!ball.GetComponent<Ball>().isInSling)
            transform.position = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);
    }
}
