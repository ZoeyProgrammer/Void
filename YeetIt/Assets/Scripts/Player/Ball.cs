using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float releaseDistance;
    public float slingcooldown;
    public float maxVelocity;
    public float maxDragDistance;
    public float minDragDistance;
    public float bounceCountDelay;
    public LayerMask wallLayers;
    private float bounceDelayCounter;
    private float radius;
    private bool isScoredAlready = false;

    private Vector2 anchorPos,mousePos,slingPos,desiredPos,desiredDirection;


    public bool isInSling = false;
    [HideInInspector] public SpringJoint2D currentSling;
    public bool isPressed = false;
    public bool isDragged;

    Rigidbody2D rb;
    GameManager gm;
    AudioManager audioMng;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        radius = GetComponent<CircleCollider2D>().radius * 0.5f;
        audioMng = GameObject.FindGameObjectWithTag(Tags.audioManager).GetComponent<AudioManager>();
    }

    private void Update()
    {
        gm.currHeight = transform.position.y / 10;

        if (isInSling && !isScoredAlready && transform.position.y / 10 > gm.height)
        {
            gm.height = transform.position.y / 10;
            isScoredAlready = true;
        }

        if (isPressed && anchorPos == Vector2.zero)
            anchorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        else if (!isPressed && anchorPos != Vector2.zero)
            anchorPos = Vector2.zero;

        if (isInSling && isPressed)
        {
            SlingBehaviour();
        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
    
    private void SlingBehaviour()
    {
        slingPos = currentSling.GetComponent<Rigidbody2D>().position + currentSling.anchor;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(anchorPos, mousePos) <= minDragDistance)
            isDragged = false;
        else
            isDragged = true;

        if (Vector2.Distance(anchorPos, mousePos) <= maxDragDistance)
            desiredPos = slingPos + (mousePos - anchorPos);
        else
            desiredPos = slingPos + (mousePos - anchorPos).normalized * maxDragDistance;

        desiredDirection = (desiredPos - slingPos).normalized;

        RaycastHit2D hit = Physics2D.CircleCast(slingPos, radius, desiredDirection, Vector2.Distance(slingPos,desiredPos), wallLayers);

        if (hit.collider == null)
            rb.position = desiredPos;
        else
        {
            Vector2 newPos = new Vector2();
            bool isViable = false;

            for (float f = 0f; isViable == false; f -= 0.2f)
            {
                RaycastHit2D hitSearch = Physics2D.CircleCast(slingPos, radius, desiredDirection, Vector2.Distance(slingPos, desiredPos) + f, wallLayers);

                if (hitSearch.collider == null)
                {
                    isViable = true;
                    newPos = slingPos + desiredDirection * (Vector2.Distance(slingPos, desiredPos) + f);
                }
            }
            rb.position = newPos;
        }
    }
    public IEnumerator Release()
    {
        yield return new WaitUntil(hasReachedReleasePoint);
        currentSling.connectedBody = null;
        GetComponent<ShootIndicator>().DestroyArrows();

        yield return new WaitForSeconds(slingcooldown);
        isInSling = false;
        isScoredAlready = false;
    }

    private bool hasReachedReleasePoint()
    {
        if (Vector2.Distance(rb.position, slingPos) <= releaseDistance)
            return true;

            return false;
    }

    public void Death()
    {
        FindObjectOfType<DeathscreenController>().OpenDeathscreen();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!isInSling && col.tag == Tags.obstacle && bounceDelayCounter <= 0)
        {
            bounceDelayCounter = bounceCountDelay;
            gm.timesBounced++;
            audioMng.PlayCollisonSound();
        }
        else
            bounceDelayCounter -= Time.deltaTime;
    }
}
