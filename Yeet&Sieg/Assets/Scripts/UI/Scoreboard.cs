using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public ScrollRect scrollRect;
    GameManager gm;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
    }

    public void JumpToTop()
    {
        scrollRect.ScrollToTop();
        //Jump to the highest Score
    }

    public void JumpToOwnHighscore()
    {
        GameObject segment = null;

        foreach (ScoreSegments s in FindObjectsOfType<ScoreSegments>())
        {
            if (s.username == gm.username)
                segment = s.gameObject;
        }

        if (segment == null)
            Debug.LogError("No Highscore for Player Found");
        else
            scrollRect.ScrollToSegment(segment.GetComponent<RectTransform>());
        //Jump to your own Score
    }

    public void CloseScoreboard()
    {
        Destroy(this.gameObject);
    }
}
