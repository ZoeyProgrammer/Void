using Firebase;
using Firebase.Extensions;
using Firebase.Analytics;
using UnityEngine;
using UnityEngine.Events;

public class FirebaseInit : MonoBehaviour
{
    public UnityEvent OnFirebaseInitialized = new UnityEvent();

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
    }
}
