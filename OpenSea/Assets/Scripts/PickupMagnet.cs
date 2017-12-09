using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickupMagnet : MonoBehaviour {

	// Configurações
	[Header("Settings")]
	public float pickupSpeed;
	public GameObject target;
	
	void Start() {
    }
	
	// Colisão
	void OnTriggerEnter(Collider other) {
		StartCoroutine(Magnet(other.gameObject));
	}
	
	// Coleta os itens
	IEnumerator Magnet(GameObject other) {
		if (other.gameObject.tag == "Pickup") {						
			while (	!Mathf.Approximately(other.transform.position.x, transform.position.x) &&
					!Mathf.Approximately(other.transform.position.y, transform.position.y) &&
					!Mathf.Approximately(other.transform.position.z, transform.position.z)) {
				yield return other.transform.DOMove(transform.position, pickupSpeed, false);
			}
			
			// Adiciona um item no save
			SaveLoadManager.instance.pickups += 1;
			PlayerPrefs.SetInt("pickups"+ SaveLoadManager.instance.slot, SaveLoadManager.instance.pickups);
			
			// Destrói o item
			Destroy(other);
		}
	}
}