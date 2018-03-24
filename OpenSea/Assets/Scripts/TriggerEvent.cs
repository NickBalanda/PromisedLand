using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour {
	
	[Tooltip("Function called when trigger enter")]
	[SerializeField] // Serialize to show field in the editor
	public UnityEvent onTriggerEnter = new UnityEvent(); // our Unity Event

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
            onTriggerEnter.Invoke();
            Destroy(GetComponent<TriggerEvent>());
        }
	}

}
