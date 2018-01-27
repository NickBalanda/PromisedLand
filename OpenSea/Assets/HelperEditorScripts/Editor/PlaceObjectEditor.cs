using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class PlaceObjectEditor : EditorWindow {

    bool placeObjects = true;
    GameObject spawnedObject;
    LayerMask placeLayers; 

    [MenuItem("Window/Object placer")]
    public static void ShowWindow() {
        GetWindow<PlaceObjectEditor>("Object placer");
    }

    public void OnEnable() {
        SceneView.onSceneGUIDelegate -= CustomUpdate;
        SceneView.onSceneGUIDelegate += CustomUpdate;
    }

    void OnGUI() {
        GUILayout.Label("Place Object by clicking on a mesh", EditorStyles.boldLabel);

        placeObjects = EditorGUILayout.Toggle("Place Objects?", placeObjects);

        spawnedObject = (GameObject)EditorGUILayout.ObjectField("Object to Spawn", spawnedObject, typeof(GameObject), true);

        GUILayout.Space(10);

        //Handles layerMask
            GUILayout.Label("Define layers that object can be placed");
            LayerMask tempMask = EditorGUILayout.MaskField(InternalEditorUtility.LayerMaskToConcatenatedLayersMask(placeLayers), InternalEditorUtility.layers);
            placeLayers = InternalEditorUtility.ConcatenatedLayersMaskToLayerMask(tempMask);
      
    }

    void CustomUpdate(SceneView sceneView) {
        if (placeObjects) {
            Event e = Event.current;

            if (e.type == EventType.MouseDown && e.button == 0) {
                RaycastHit hit;
                Ray ray = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, Camera.current.pixelHeight - e.mousePosition.y, 0));
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, placeLayers)) {
                    GameObject placedObject = (GameObject)PrefabUtility.InstantiatePrefab(spawnedObject);
                    placedObject.transform.position = hit.point;
                }
            }
        }   
    }
}
