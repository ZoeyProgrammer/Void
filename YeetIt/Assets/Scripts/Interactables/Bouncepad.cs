﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    public float impulsePower;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Tags.ball)
        {
            col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.GetComponent<Rigidbody2D>().AddForce(transform.up * impulsePower, ForceMode2D.Impulse);
        }
    }
}