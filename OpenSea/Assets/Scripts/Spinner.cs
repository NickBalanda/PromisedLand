using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

	public float speed;
	public float y;
	public float x;
	public float z;
	
	void Start () {	}
	
	void Update () { transform.Rotate(x*speed,y*speed,z*speed); }
	
}
