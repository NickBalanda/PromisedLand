using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class TitleScreenCutscene : MonoBehaviour {	
	
	[Header("> Actors")]
	public Camera cam;
	public Image fadePanel;
	public GameObject initialMenu;
	
	private AudioSource cameraAudio;
	private AudioSource scriptAudio;
	
	// Inicialização
	void Start () {
        fadePanel.gameObject.SetActive(true);
		cameraAudio = cam.GetComponent<AudioSource>();
		scriptAudio = GetComponent<AudioSource>();
		
		// Inicia a cena
		StartCoroutine(Cutscene());
	}
	
	IEnumerator Cutscene() {		
		// Fade in
        
		fadePanel.DOFade(0, 1);
		
		yield return new WaitForSeconds(1);
		
		// Começa a música
		cameraAudio.Play();
		
		yield return new WaitForSeconds(0.5f);
		
		// Ativa o menu
		initialMenu.SetActive(true);
	}
}