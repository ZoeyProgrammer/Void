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
        }
    }

    private void Update()   //Probalby not the most beautifull solution, but well.. it works
    {
        if (spring.connectedBody == null)
            GetComponent<CircleCollider2D>().enabled = true;
        else
            GetComponent<CircleCollider2D>().enabled = false;
    }
}
