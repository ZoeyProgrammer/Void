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
        return "users/" + gm.userID;
    }

    public void SaveHighscore()
    {
        database.GetReference(playerKey() + "/highscore").SetValueAsync(gm.highscore);
    }

    public async void RetrieveHighscore()
    {
        DataSnapshot score = await database.GetReference(playerKey() + "/highscore").GetValueAsync();
        gm.highscore = int.Parse(score.Value.ToString());
    }

    public async Task<List<ScoreSave>> HighscoreList()
    {
        Debug.Log("Fetching Highscore data..");
        List<ScoreSave> allSegments = new List<ScoreSave>();
        foreach (string friendID in gm.friendList)
        {
            DataSnapshot friendScore = await database.GetReference("users/" + friendID + "/highscore").GetValueAsync();
            if (friendScore.Exists)
            {
                DataSnapshot friendName = await database.GetReference("users/" + friendID + "/name").GetValueAsync();
                if (friendName.Exists)
                    allSegments.Add(new ScoreSave(friendName.Value.ToString() , int.Parse(friendScore.Value.ToString()), 0));
            }
        }
        return allSegments;
    }
}
