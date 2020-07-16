using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncepad : MonoBehaviour
{
    public float impulsePower;
    AudioManager audioMng;

    private void Start()
    {
        audioMng = GameObject.FindGameObjectWithTag(Tags.audioManager).GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Tags.ball)
        {
            if (!col.GetComponent<Ball>().isInSling && col.GetComponent<Ball>().currentSling.connectedBody == null)
            {
                col.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                col.GetComponent<Rigidbody2D>().AddForce(transform.up * impulsePower, ForceMode2D.Impulse);
                audioMng.PlayBouncepadSound();
            }
        }
    }
}
