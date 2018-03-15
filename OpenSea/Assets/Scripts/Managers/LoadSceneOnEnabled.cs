using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnEnabled : MonoBehaviour {

    public LoadingScreenManager load;

    private void OnEnable() {
        load.SmoothLoadScene("HUB");
    }
}
