using UnityEditor;
using UnityEngine;

public class ExampleWindow : EditorWindow {

    [MenuItem("Window/Example")]
    public static void ShowWindow() {
        GetWindow<ExampleWindow>("Example");
    }

    private void OnGUI() {
        GUILayout.Label("This is a label", EditorStyles.boldLabel);
    }

}
