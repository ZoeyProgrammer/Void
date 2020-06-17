using System.Threading.Tasks;
using System.Collections.Generic;
using Firebase;
using Firebase.Database;
using UnityEngine;
using UnityEngine.Events;

public class DBManager : MonoBehaviour
{
    private FirebaseDatabase database;

    GameManager gm;

    private void Start()
    {
        gm = GetComponent<GameManager>();
        database = FirebaseDatabase.DefaultInstance;
    }

    public string playerKey()
    {
        return "users/" + gm.username;
    }

    public void SaveHighscore()
    {
        database.GetReference(playerKey() + "/highscore").SetValueAsync(gm.highscore);
    }

    public async Task<List<ScoreSave>> HighscoreList()
    {
        Debug.Log("Fetching Highscore data..");
        List<ScoreSave> allSegments = new List<ScoreSave>();
        foreach (string friend in gm.friendList)
        {
            DataSnapshot friendScore = await database.GetReference("users/" + friend + "/highscore").GetValueAsync();
            if (friendScore.Exists)
            {
                allSegments.Add(new ScoreSave(friend, int.Parse(friendScore.Value.ToString())));
            }
        }
        return allSegments;
    }
}
