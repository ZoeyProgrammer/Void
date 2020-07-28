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

    private ScoreSave playerSave; 
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
        //GameObject segment = Instantiate(scoreSegment, scoreContent);
        playerSave = new ScoreSave("You", gm.highscore, 0);
        //segment.GetComponent<ScoreSegments>().scoreSave = playerSave;
    }

    private IEnumerator LoadSegments()
    {
        var highscoreListTask = db.HighscoreList();
        yield return new WaitUntil(() => highscoreListTask.IsCompleted);

        highscoreListTask.Result.Add(playerSave);
        ScoreSave[] segmentsOrdered = highscoreListTask.Result.OrderByDescending(x => x.highscore).ToArray();
        for (int i = 0; i < segmentsOrdered.Length; i++)
        {
            Debug.Log(segmentsOrdered[i].username + " Score:" + segmentsOrdered[i].highscore);
            segmentsOrdered[i].rank = i + 1;
        }

        foreach (ScoreSave save in segmentsOrdered)
        {
            if (save.rank <= 3 && save.rank != playerSave.rank ||
                save.rank == playerSave.rank + 1 ||
                save.rank == playerSave.rank -1 ||
                save.rank == playerSave.rank)
            {
                GameObject segment = Instantiate(scoreSegment, scoreContent);
                segment.GetComponent<ScoreSegments>().scoreSave = save;
            }
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
            if (s.scoreSave.username == "You")
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
        ScoreSegments[] segmentsOrdered = segmentList.OrderBy(x => x.scoreSave.rank).ToArray();
        
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
