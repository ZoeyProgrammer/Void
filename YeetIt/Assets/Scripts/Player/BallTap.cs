using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BallTap : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    Ball ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag(Tags.ball).GetComponent<Ball>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ball.isPressed = true;
        if (ball.isInSling)
            ball.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ball.isPressed = false;
        if (ball.isInSling)
        {
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            StartCoroutine(ball.Release());
        }
    }
}
