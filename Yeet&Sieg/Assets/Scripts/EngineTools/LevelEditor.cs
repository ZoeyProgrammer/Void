#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class LevelEditor : EditorWindow
{
    private float snippetWidth = 4;
    private float snippetLength = 1;
    private string snippetName;
    private int difficultyClass = 0;

    [MenuItem("Window/LevelEditor")]
    public static void ShowWindow ()
    {
        GetWindow<LevelEditor>();
    }

    private void OnGUI()
    {
        GUILayout.Label("Please only use this in the LevelEditor Scene!", EditorStyles.boldLabel);
        GUILayout.Label("Anything else 'could' do substantial damage.", EditorStyles.boldLabel);
        GUILayout.Space(20);

        GUILayout.Label("Resetting Options", EditorStyles.boldLabel);
        if(GUILayout.Button("Reset Walls"))
        {
            ResetWalls();
        }
        if (GUILayout.Button("Clear Scene"))
        {
            Debug.Log("Clearing all Assets");
            ClearScene();
        }

        GUILayout.Label("Debugging Options", EditorStyles.boldLabel);
        if(GUILayout.Button("Error Check"))
        {
            Debug.Log("Checking for OutOfBounds..");
            //Actually Check for Out of Bounds here
            Debug.Log("Checking for Clipping..");
            //Actually Check for Clipping
        }
        if(GUILayout.Button("Run Test"))
        {
            EditorApplication.isPlaying = true;
        }

        GUILayout.Label("Parameters", EditorStyles.boldLabel);
        snippetName = EditorGUILayout.TextField("Snippet Name", snippetName);
        snippetLength = EditorGUILayout.Slider("Snippet Length", snippetLength, 1f, 20f);
        difficultyClass = EditorGUILayout.IntSlider("Difficulty Class", difficultyClass, 0, 20);
        if(GUILayout.Button("Commit as Prefab"))
        {
            if (CreatePrefab())
            {
                Debug.Log("Prefab Creation Successfull");
                AddPrefabToList();
            }
            else
                Debug.Log("Prefab Creation ERROR");
        }
    }

    private void ResetWalls()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag(Tags.levelEditWall))
        {
            if (wall.name.Contains("Left"))
                wall.transform.position = new Vector3(-snippetWidth * 5 - 5, 0);
            else if (wall.name.Contains("Right"))
                wall.transform.position = new Vector3(snippetWidth * 5 + 5, 0);
        }
    }

    private void ClearScene()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag(Tags.obstacle)) {
            DestroyImmediate(wall);
        }
    }

    private bool CreatePrefab()
    {
        GameObject snippet = GameObject.FindGameObjectWithTag(Tags.snippet);
        snippet.GetComponent<Snippet>().snippetLength = snippetLength;
        snippet.GetComponent<Snippet>().difficultyClass = difficultyClass;
        bool success = PrefabUtility.SaveAsPrefabAsset(snippet, "Assets/Prefabs/Temporary/" + snippetName + ".prefab", out success);
        return success;
    }

    private void AddPrefabToList()
    {
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Temporary/" + snippetName + ".prefab");
        SnippetList snippetList = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Temporary/SnippetList.prefab").GetComponent<SnippetList>();
        if (!snippetList.snippetList.Contains(prefab))
            snippetList.snippetList.Add(prefab);
        else
            Debug.Log("That Prefab was already Comitted!");
    }

    private void OnInspectorUpdate()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag(Tags.levelEditWall))
        {
            wall.transform.localScale = new Vector3(wall.transform.localScale.x,snippetLength,wall.transform.localScale.z);
        }
    }
}
#endif
