using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootIndicator : MonoBehaviour
{
    public float tolerance;
    public GameObject arrows;

    private GameObject currentArrows = null;
    private GameObject arrow00;
    private GameObject arrow01;
    private GameObject arrow02;
    private GameObject arrow03;
    private Vector3 ballPos;
    private Vector3 slingPos;

    Ball ball;

    private void Start()
    {
        ball = GetComponent<Ball>();
    }

    private void Update()
    {

        if (ball.isInSling && ball.currentSling.connectedBody != null && currentArrows == null)
            CreateArrows();
        else if (ball.isInSling && currentArrows != null)
        {
            slingPos = ball.currentSling.transform.position;
            ballPos = ball.transform.position;
            MoveArrows();
        }
    }

    private void CreateArrows()
    {
        slingPos = ball.currentSling.transform.position;
        currentArrows = Instantiate(arrows, slingPos, Quaternion.identity);
        arrow00 = GameObject.Find("Arrow00");
        arrow01 = GameObject.Find("Arrow01");
        arrow02 = GameObject.Find("Arrow02");
        arrow03 = GameObject.Find("Arrow03");

    }

    public void DestroyArrows()
    {
        Destroy(currentArrows);
        arrow01 = null;
        arrow02 = null;
        arrow03 = null;
    }

    private void MoveArrows()
    {
        if (Vector3.Distance(slingPos,ballPos) <= tolerance)
        {
            //Remain in standart Pos
        }
        else
        {
            Vector3 dir = ballPos - slingPos;
            dir = ball.currentSling.transform.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            currentArrows.transform.eulerAngles = new Vector3(0, 0, angle);

            float distance = Vector3.Distance(slingPos, ballPos);
            arrow00.transform.position = ballPos;
            arrow01.transform.localPosition = Vector3.up * distance;
            arrow02.transform.localPosition = Vector3.up * distance * 0.7f;
            arrow03.transform.localPosition = Vector3.up * distance * 0.3f;
        }
    }
}
