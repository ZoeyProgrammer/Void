#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Moveability))]
public class MoveabiltyEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Moveability moveability = (Moveability)target;

        if (GUILayout.Button("Add Keyframe"))
        {
            GameObject keyframe = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Technical/Keyframe.prefab");
            GameObject key = Instantiate(keyframe, moveability.transform.position, Quaternion.identity);
            moveability.keyframes.Add(key.transform);
        }

        GUILayout.BeginHorizontal();
            if (GUILayout.RepeatButton("Test"))
            {
                moveability.Move();
            }
            if (GUILayout.RepeatButton("Reset"))
            {
                moveability.transform.position = moveability.keyframes[0].position;
                moveability.transform.rotation = moveability.keyframes[0].rotation;
                moveability.currentKeyframe = 0;
            }
        GUILayout.EndHorizontal();

        GUILayout.Label("Warning - This removes all assigned Keyframes", EditorStyles.boldLabel);
        if (GUILayout.Button("Remove Moving Property"))
        {
            foreach (Transform t in moveability.keyframes)
            {
                DestroyImmediate(t.gameObject);
            }
            DestroyImmediate(moveability.GetComponent<Rigidbody2D>());
            DestroyImmediate(moveability);
        }
    }
}
#endif