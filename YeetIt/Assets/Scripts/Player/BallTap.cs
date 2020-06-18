using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTap : MonoBehaviour
{
    Ball ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag(Tags.ball).GetComponent<Ball>();
    }

    private void OnMouseDown()
    {
        ball.isPressed = true;
        if (ball.isInSling)
            ball.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    private void OnMouseUp()
    {
        ball.isPressed = false;
        if (ball.isInSling)
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            StartCoroutine(ball.Release());
        }
    }
}
