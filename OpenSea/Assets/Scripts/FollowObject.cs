using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour {

	public Transform whatToFollow;
	public Vector3 offset;

	void Start () {}
	
	void Update () {
		transform.position = new Vector3 (whatToFollow.position.x + offset.x, whatToFollow.position.y + offset.y, whatToFollow.position.z + offset.z);
	}
}
