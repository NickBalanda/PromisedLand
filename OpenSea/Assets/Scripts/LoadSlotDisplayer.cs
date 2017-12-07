using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadSlotDisplayer : MonoBehaviour {
	
	[Header("> Settings")]
	public int slot;
	
	public Text name;
	public Text pickups;
	public Text progress;
	
	void Update () {
		name.text = PlayerPrefs.GetString("name"+slot);
		pickups.text = "Energia: " + PlayerPrefs.GetInt("pickups"+slot).ToString();
		progress.text = PlayerPrefs.GetFloat("progress"+slot).ToString() + "%";
	}
}