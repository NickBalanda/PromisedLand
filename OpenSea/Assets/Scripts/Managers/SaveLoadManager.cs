using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

	[Header("> Settings")]
	public string slot;
	public InputField nameInput;
	
	[Header("> Keys")]
	public string playerName;
	public int pickups;
	public float progress;
	
	void Awake () {DontDestroyOnLoad(gameObject.GetComponent<SaveLoadManager>());}
	
	// Determina o slot a ser usado
	public void SetSlot(string slotNumber) {slot = slotNumber;}
	
	// Determina o nome do save
	public void SetName(string name) {playerName = name;}
	
	// Cria um novo save com as configurações atuais
	public void CreateSave() {
		PlayerPrefs.SetString("name"+slot, playerName);
		PlayerPrefs.SetInt("pickups"+slot, 0);
		PlayerPrefs.SetFloat("progress"+slot, 0);
	}
	
	// Carrega o slot selecionado
	public void Load(string slotNumber) {
		slot = slotNumber;
		playerName = PlayerPrefs.GetString("name"+slot);
		pickups = PlayerPrefs.GetInt("pickups"+slot);
		progress = PlayerPrefs.GetFloat("progress"+slot);
	}
	
	// Deleta o slot selecionado
	public void DeleteSave(string slotNumber) {	
		PlayerPrefs.DeleteKey("name"+slotNumber);
		PlayerPrefs.DeleteKey("pickups"+slotNumber);
		PlayerPrefs.DeleteKey("progress"+slotNumber);
	}
	
	//Deleta todos os slots
	public void DeleteAllSaves() {PlayerPrefs.DeleteAll();}
}