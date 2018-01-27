using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject obj;
    public Vector3 spawnPoint;


    public void BuildObject() {
        Instantiate(obj, spawnPoint, Quaternion.identity);
    }
}
