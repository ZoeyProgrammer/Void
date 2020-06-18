using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyClass
{
    public List<GameObject> list;
    public HeightClass heightClass;

    public DifficultyClass(List<GameObject> list, HeightClass heightClass)
    {
        this.list = list;
        this.heightClass = heightClass;
    }
}
