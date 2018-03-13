using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {

	public GameObject arrow;
	public float animationSpeed = 4;
    Animation arrowAnim; 
	void Start () {
        arrowAnim = arrow.GetComponent<Animation>();

        arrowAnim["Play"].speed = animationSpeed;
	}
	
	public LayerMask groundLayer;

	void Update () {
		
		if( Input.GetMouseButtonDown(0)){
			
			RaycastHit hit;
			if (Physics.Raycast	(Camera.main.ScreenPointToRay (Input.mousePosition),out hit, Mathf.Infinity, groundLayer)) {
				
				transform.position = hit.point;
                arrowAnim.Rewind("Play");
                arrowAnim.Play("Play", PlayMode.StopAll);
			}
		}
	}
}
