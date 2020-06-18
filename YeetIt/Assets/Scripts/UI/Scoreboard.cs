using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public ScrollRect scrollRect;
    public GameObject scoreSegment;
    public Transform scoreContent;

    GameManager gm;
    DBManager db;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<GameManager>();
        db = GameObject.FindGameObjectWithTag(Tags.gm).GetComponent<DBManager>();
    }

    private void Start()
    {
        LoadPlayerScore();
        StartCoroutine(LoadSegments());
    }

    private void LoadPlayerScore()
    {
        GameObject segment = Instantiate(scoreSegment, scoreContent);
        segment.GetComponent<ScoreSegments>().username = "You";
        segment.GetComponent<ScoreSegments>().highscore = gm.highscore;
    }

    private IEnumerator LoadSegments()
    {
        var highscoreListTask = db.HighscoreList();
        yield return new WaitUntil(() => highscoreListTask.IsCompleted);
        foreach (ScoreSave save in highscoreListTask.Result)
        {
            Debug.Log(save.username + " " + save.highscore);
            GameObject segment = Instantiate(scoreSegment,scoreContent);
            segment.GetComponent<ScoreSegments>().username = save.username;
            segment.GetComponent<ScoreSegments>().highscore = save.highscore;
        }
        SortSegments();
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
            if (s.username == "You")
                segment = s.gameObject;
        }

        if (segment == null)
            Debug.LogError("No Highscore for Player Found");
        else
            scrollRect.ScrollToSegment(segment.GetComponent<RectTransform>());
        //Jump to your own Score
    }

    public void SortSegments()
    {
        ScoreSegments[] segmentList = FindObjectsOfType<ScoreSegments>();
        ScoreSegments[] segmentsOrdered = segmentList.OrderByDescending(x => x.highscore).ToArray();
        
        for (int i = 0; i < segmentsOrdered.Length; i++)
        {
            segmentsOrdered[i].transform.SetSiblingIndex(i);
        }
    }

    public void CloseScoreboard()
    {
        Destroy(this.gameObject);
    }
}
