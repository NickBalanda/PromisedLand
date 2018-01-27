using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnObject))]
public class SpawnObjectEditor : Editor {

    public override void OnInspectorGUI() {

        EditorGUILayout.HelpBox("Use this component to spawn an object at defined position", MessageType.Info);

        DrawDefaultInspector();

        SpawnObject myScript = (SpawnObject)target;

        EditorGUILayout.Space();

        if(GUILayout.Button("Spawn Object")) {
            myScript.BuildObject();
        }
    }
}
