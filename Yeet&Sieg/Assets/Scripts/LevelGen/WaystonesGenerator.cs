using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaystonesGenerator : MonoBehaviour
{
    public GameObject waystone;
    public float unitsBetweenWaystones;

    private float currentGenHeight = 0;

    LevelGenerator levelGen;
    GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        levelGen = GetComponent<LevelGenerator>();
        currentGenHeight = unitsBetweenWaystones;
    }

    private void Update()
    {
        if (currentGenHeight <= gm.currHeight + levelGen.preGenerationLimit)
        {
            GenerateWaystone();
        }
    }

    private void GenerateWaystone()
    {
        Instantiate<GameObject>(waystone, new Vector3(0f, currentGenHeight * 10, 0f), Quaternion.identity);
        currentGenHeight += unitsBetweenWaystones;
    }
}
