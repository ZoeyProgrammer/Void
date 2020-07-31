using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Slingshot : MonoBehaviour
{
    public Animator animator;
    public Light2D lights;
    public Color blue;

    private Color startColour;
    private Ball ball;
    private bool isBlue;

    SpringJoint2D spring;

    private void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        startColour = lights.color;
    }

    private void Update()
    {
        if (isBlue && ball != null && ball.currentSling != spring)
        {
            TurnBack();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Tags.ball && !col.GetComponent<Ball>().isInSling)
        {
            TurnBlue();
            ball = col.GetComponent<Ball>();
            col.GetComponent<Ball>().isInSling = true;
            col.GetComponent<Ball>().currentSling = spring;
            spring.connectedBody = col.GetComponent<Rigidbody2D>();
            col.GetComponent<Rigidbody2D>().position = GetComponent<Rigidbody2D>().position + spring.anchor;
            col.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            //col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void TurnBlue()
    {
        animator.SetBool("isBlue", true);
        lights.color = blue;
        isBlue = true;
    }

    public void TurnBack()
    {
        animator.SetBool("isBlue", false);
        lights.color = startColour;
        isBlue = false;
    }
}
