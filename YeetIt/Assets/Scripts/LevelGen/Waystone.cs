using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Waystone : MonoBehaviour
{
    public TextMeshPro text;

    private void Start()
    {
        float height = transform.position.y / 10;
        text.text = height.ToString();
    }
}
