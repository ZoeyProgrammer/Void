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
    public LayerMask wallLayers;
    private float bounceDelayCounter;
    private float radius;
    private bool isScoredAlready = false;

    public bool isInSling = false;
    [HideInInspector] public SpringJoint2D currentSling;
    public bool isPressed = false;

    Rigidbody2D rb;
    GameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        radius = GetComponent<CircleCollider2D>().radius * 0.5f;
    }

    private void Update()
    {
        if (isInSling && !isScoredAlready && transform.position.y / 10 > gm.height)
        {
            gm.height = transform.position.y / 10;
            isScoredAlready = true;
        }

        if (isInSling && isPressed)
        {
            Vector2 anchorPos = currentSling.GetComponent<Rigidbody2D>().position;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 desiredPos = Vector2.zero;
            if (Vector3.Distance(mousePos, anchorPos) <= maxDragDistance)
                desiredPos = mousePos;
            else
                desiredPos = anchorPos + (mousePos - anchorPos).normalized * maxDragDistance;

            Vector2 desiredDirection = (desiredPos - anchorPos).normalized;

            RaycastHit2D hit1 = Physics2D.Linecast(anchorPos, desiredPos + desiredDirection * radius, wallLayers);
            RaycastHit2D hit2 = Physics2D.Linecast(desiredPos + Vector2.Perpendicular(desiredDirection), desiredPos + Vector2.Perpendicular(-desiredDirection) * radius, wallLayers);
            
            //Debug Draws
            Debug.DrawLine(anchorPos, desiredPos + desiredDirection * radius, Color.magenta);
            Debug.DrawLine(desiredPos + Vector2.Perpendicular(desiredDirection), desiredPos + Vector2.Perpendicular(-desiredDirection) * radius, Color.red);

            if (hit1.collider == null && hit2.collider == null)
                rb.position = desiredPos;
            else
            {
                //Search for the nearest opening.
                Vector2 currentPos = new Vector2();
                bool isViable = false;
                for (float f = 0f; isViable == false; f -= 0.1f)
                {
                    Vector2 hitPoint = new Vector2();
                    if (hit1.collider != null)
                        hitPoint = hit1.point;
                    else
                        hitPoint = desiredPos;

                    RaycastHit2D hitSearch = Physics2D.Linecast(hitPoint + desiredDirection * (f - radius) + Vector2.Perpendicular(desiredDirection), hitPoint + desiredDirection * (f - radius) + Vector2.Perpendicular(-desiredDirection) * radius, wallLayers);
                    Debug.DrawLine(hitPoint + desiredDirection * (f - radius) + Vector2.Perpendicular(desiredDirection), hitPoint + desiredDirection * (f - radius) + Vector2.Perpendicular(-desiredDirection) * radius, Color.blue);

                    if (hitSearch.collider == null)
                    {
                        isViable = true;
                        currentPos = hitPoint + desiredDirection * (f - radius);
                    }
                }
                rb.position = currentPos;
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

        yield return new WaitForSeconds(slingcooldown);
        isInSling = false;
        isScoredAlready = false;
        GetComponent<ShootIndicator>().DestroyArrows();
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
        if (!isInSling && col.tag == Tags.obstacle && bounceDelayCounter <= 0)
        {
            bounceDelayCounter = bounceCountDelay;
            gm.timesBounced++;
        }
        else
            bounceDelayCounter -= Time.deltaTime;
    }
}
