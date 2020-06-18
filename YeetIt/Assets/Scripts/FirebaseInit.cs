using Firebase;
using Firebase.Extensions;
using Firebase.Analytics;
using Firebase.Auth;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{
    public UnityEvent OnFirebaseInitialized = new UnityEvent();

    GameManager gm;
    DBManager db;

    private void Awake()
    {
        gm = GetComponent<GameManager>();
        db = GetComponent<DBManager>();
    }

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            if (task.Exception != null)
            {
                Debug.LogError($"Failed to initilaize Firebase with {task.Exception}");
                return;
            }
            OnFirebaseInitialized.Invoke();
            Debug.Log("Firebase has been Initilaized");
        });

        FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        auth.SignInAnonymouslyAsync().ContinueWith(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError($"Failed to log in Anonymously with {task.Exception}");
                return;
            }

            FirebaseUser newUser = task.Result;
            Debug.Log($"User signed in successfully: {newUser.DisplayName} ({newUser.UserId})");
            gm.userID = newUser.UserId;

            db.RetrieveHighscore();
        });

    }
}
