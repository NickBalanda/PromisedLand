using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnEnabled : MonoBehaviour {

    public LoadingScreenManager load;
    public string scene = "HUB";
    private void OnEnable() {
        load.SmoothLoadScene(scene);
    }
}
