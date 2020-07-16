using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wall;
    private float wallOffset = 30;
    private float wallHeight = 30;
    private float currentGenHeight = -10;

    LevelGenerator levelGen;
    GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        levelGen = GetComponent<LevelGenerator>();
    }

    private void Update()
    {
        if (currentGenHeight <= gm.currHeight + levelGen.preGenerationLimit)
        {
            GenerateWalls();
        }
    }

    private void GenerateWalls()
    {
        Instantiate<GameObject>(wall, new Vector3(wallOffset, currentGenHeight * 10, 0f), Quaternion.identity);
        Instantiate<GameObject>(wall, new Vector3(-wallOffset, currentGenHeight * 10, 0f), Quaternion.identity);

        currentGenHeight += wallHeight/10;
    }
    //Can really only do this, once we know how the Walls should get done
}
