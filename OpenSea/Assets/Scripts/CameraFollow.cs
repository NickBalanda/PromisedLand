using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("Target")]
    public Transform target;

    [Header("Distance")]
    float distance;
    public Vector3 offset;
    [Tooltip("Distance is the size of the Main Camera")]
    public float minDistance = 10, maxDistance = 16;

    [Header("Speeds")]
    public float smoothSpeed = 5;
    public float scrollSensitivity = 1;

    void Start () {
        
	}

	void LateUpdate () {
        if (!target) {
            return;
        }
        float num = Input.GetAxis("Mouse ScrollWheel");
        distance -= num * scrollSensitivity;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);
        Camera.main.orthographicSize = distance;

        Vector3 pos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, pos, smoothSpeed * Time.deltaTime);
	}


}
