using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float releaseDistance;
    public float slingcooldown;
    public float maxVelocity;
    public float maxDragDistance;
    public float bounceCountDelay;
    private float bounceDelayCounter;

    public bool isInSling = false;
    [HideInInspector] public SpringJoint2D currentSling;

    public bool isPressed = false;

    Rigidbody2D rb;
    GameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
    }

    private void Update()
    {
        if (isInSling && isPressed)
        {
            Vector2 anchorPos = currentSling.GetComponent<Rigidbody2D>().position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(mousePos, anchorPos) <= maxDragDistance)
                rb.position = mousePos;
            else
            {
                rb.position = anchorPos + (mousePos - anchorPos).normalized * maxDragDistance;
            }
        }
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
    
    IEnumerator Release()
    {
        yield return new WaitUntil(hasReachedReleasePoint);
        currentSling.connectedBody = null;
        Debug.Log("FIRED");

        yield return new WaitForSeconds(slingcooldown);
        isInSling = false;
        Debug.Log("Ready to Reload");
    }

    private bool hasReachedReleasePoint()
    {
        Vector2 anchorPos = currentSling.GetComponent<Rigidbody2D>().position + currentSling.anchor;
        if (Vector2.Distance(rb.position, anchorPos) <= releaseDistance)
            return true;

            return false;
    }

    private void OnMouseDown()
    {
        isPressed = true;
        if (isInSling)
            rb.isKinematic = true;
    }

    private void OnMouseUp()
    {
        isPressed = false;
        if (isInSling)
        {
            rb.isKinematic = false;
            StartCoroutine(Release());
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == Tags.obstacle && bounceDelayCounter <= 0)
        {
            bounceDelayCounter = bounceCountDelay;
            gm.timesBounced++;
        }
        else
            bounceDelayCounter -= Time.deltaTime;
    }
}
