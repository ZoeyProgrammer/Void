using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    SpringJoint2D spring;

    private void Start()
    {
        spring = GetComponent<SpringJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Tags.ball && !col.GetComponent<Ball>().isInSling)
        {
            col.GetComponent<Ball>().isInSling = true;
            col.GetComponent<Ball>().currentSling = spring;
            spring.connectedBody = col.GetComponent<Rigidbody2D>();
            col.GetComponent<Rigidbody2D>().position = GetComponent<Rigidbody2D>().position + spring.anchor;
            col.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            //col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
