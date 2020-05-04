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

        GUILayout.Label("Parameters", EditorStyles.boldLabel);
        snippetName = EditorGUILayout.TextField("Snippet Name", snippetName);
        snippetLength = EditorGUILayout.Slider("Snippet Length", snippetLength, 1f, 20f);
        difficultyClass = EditorGUILayout.IntField("Difficulty Class", difficultyClass);
        if(GUILayout.Button("Create Snippet Prefab"))
        {
            if (CreatePrefab())
                Debug.Log("Prefab Creation Successfull");
            else
                Debug.Log("Prefab Creation ERROR");
        }
        if (GUILayout.Button("Commit Snippet"))
        {
            //Code to add that Prefab to Adressables, so the generator can access it.
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
        //Add the Difficulty Class and Length to a new Type, which sits on the Snippet Prefab, so the Generator can access the data.
        GameObject snippet = GameObject.FindGameObjectWithTag(Tags.snippet);
        bool success = PrefabUtility.SaveAsPrefabAsset(snippet, "Assets/Prefabs/Temporary/" + difficultyClass + "_" + snippetLength + "_" + snippetName + ".prefab", out success);
        return success;
    }

    private void OnInspectorUpdate()
    {
        foreach (GameObject wall in GameObject.FindGameObjectsWithTag(Tags.levelEditWall))
        {
            wall.transform.localScale = new Vector3(wall.transform.localScale.x,snippetLength,wall.transform.localScale.z);
        }
    }
}
