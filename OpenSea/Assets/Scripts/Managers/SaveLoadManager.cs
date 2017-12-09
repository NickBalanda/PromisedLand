using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour {

	[Header("> Settings")]
	public string slot;
	
	[Header("> Keys")]
	public string playerName;
	public int pickups;
	public float progress;

    public static SaveLoadManager instance;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Determina o slot a ser usado
    public void SetSlot(string slotNumber) {slot = slotNumber;}
	
	
	// Cria um novo save com as configurações atuais
	public void CreateSave() {
		PlayerPrefs.SetInt("pickups"+slot, 0);
		PlayerPrefs.SetFloat("progress"+slot, 0);
	}
	
	// Carrega o slot selecionado
	public void Load(string slotNumber) {
		slot = slotNumber;
		pickups = PlayerPrefs.GetInt("pickups"+slot);
		progress = PlayerPrefs.GetFloat("progress"+slot);
	}
	
	// Deleta o slot selecionado
	public void DeleteSave(string slotNumber) {	
		PlayerPrefs.DeleteKey("pickups"+slotNumber);
		PlayerPrefs.DeleteKey("progress"+slotNumber);
	}
	
	//Deleta todos os slots
	public void DeleteAllSaves() {PlayerPrefs.DeleteAll();}
}