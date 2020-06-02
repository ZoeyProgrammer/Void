using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class LevelGenerator : MonoBehaviour
{
    public SnippetList snippetList;

    GameManager gm;

    private List<DifficultyClass> dcList = new List<DifficultyClass>();
    public HeightClass[] hcList = new HeightClass[21];
    [SerializeField]private float currentGenHeight = 0;
    public float preGenerationLimit;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
    }

    private void Start()
    {
        int i = 0;
        while (i <= 20)
        {
            List<GameObject> list = snippetList.snippetList.FindAll(x => x.GetComponent<Snippet>().difficultyClass == i);
            dcList.Add(new DifficultyClass(list, hcList[i]));
            i++;
        }

        GenerateSnippit();
    }

    private void Update()
    {
        if (currentGenHeight <= gm.height + preGenerationLimit)
        {
            GenerateSnippit();
        }
    }

    private void GenerateSnippit()
    {
        List<DifficultyClass> genDcList = dcList.FindAll(x => x.heightClass.minHeight <= currentGenHeight && x.heightClass.maxHeight >= currentGenHeight);

        List<GameObject> genSnippitList = new List<GameObject>();
        foreach (DifficultyClass dc in genDcList)
        {
            foreach (GameObject snippet in dc.list)
                genSnippitList.Add(snippet);
        }

        int randomIndex = Random.Range(0, genSnippitList.Count);
        GameObject genSnippet = Instantiate<GameObject>(genSnippitList[randomIndex], new Vector3(0f,currentGenHeight * 10,0f), Quaternion.identity);
        currentGenHeight += genSnippet.GetComponent<Snippet>().snippetLength;
    }

}
