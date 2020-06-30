#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoveabiltyMark))]
public class MoveabiltyAdder : Editor
{
    public override void OnInspectorGUI()
    {
        MoveabiltyMark obj = (MoveabiltyMark)target;


        if (obj.GetComponent<Moveability>() == null)
        {
            if (GUILayout.Button("Make Moving Object"))
            {
                obj.gameObject.AddComponent(typeof(Moveability));
                obj.gameObject.AddComponent(typeof(Rigidbody2D));
                GameObject keyframe = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Technical/Keyframe.prefab");
                GameObject key = Instantiate(keyframe, obj.transform.position, Quaternion.identity);

                obj.GetComponent<Moveability>().keyframes.Add(key.transform);
            }
        }
        else
            GUILayout.Label("My work here is done");
    }
}
#endif
