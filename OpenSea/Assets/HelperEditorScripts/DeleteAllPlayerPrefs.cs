using UnityEditor;
using UnityEngine;

public class DeleteAllPlayerPrefs : MonoBehaviour {

    [MenuItem("Utils/Delete All PlayerPrefs")]
    static public void DeletePlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }
}
