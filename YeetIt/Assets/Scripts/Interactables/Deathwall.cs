using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathwall : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    GameObject ball;
    Rigidbody2D rb;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag(Tags.ball);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((ball.transform.position.y - transform.position.y) < maxDistance)
        {
            rb.velocity = speed * Vector2.up;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, ball.transform.position.y - maxDistance, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Tags.ball)
        {
            col.GetComponent<Ball>().Death();
        }
    }
}
