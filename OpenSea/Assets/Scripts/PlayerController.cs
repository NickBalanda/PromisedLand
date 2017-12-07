using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour {
	
	// Variáveis
	[Header("> Movement")]
	public bool controllerActive;
	public bool diveActive;
	public bool sailing;
	
	[Header("- Sail")]
	public float sailSpeed;
	public float sailRotationSpeed;
	
	[Header("- Swim")]
	public float swimSpeed;
	public float swimRotationSpeed;
	public BoxCollider surface;
	public GameObject waterDistortion;
	
	[Header("- Camera")]
	public GameObject camera;
	public bool cameraLeft;
	public Transform leftAngle;
	public Transform rightAngle;
	
	[Space(10)]
	
	[Header("> UI")]
	public GameObject pausePanel;
	
	[Space(10)]
	
	[Header("> Animation")]
	public GameObject trirreme;
	public Animation diveAnimation;
	private Animator trirremeAnim;
	
	[Space(10)]
	
	[Header("> Particle Systems")]
	public ParticleSystem waterSplash;
	public ParticleSystem talismanParticles;
	private ParticleSystem.EmissionModule waterSplashEmission;
	
	Quaternion originalRotation;
	Vector3 originalPosition;
	
	// Save Manager
	private SaveLoadManager saveData;
	
	// Inicialização
	void Start () {
		trirremeAnim = trirreme.GetComponent<Animator>();
		waterSplashEmission = waterSplash.emission;
		saveData = GameObject.Find("SaveLoadManager").GetComponent<SaveLoadManager>();
		
		originalRotation = Quaternion.identity;
		originalPosition = transform.position;
	}
	
	void Update () {
		// Pausa
		if (Input.GetButtonDown("Pausa")) {
			pausePanel.SetActive(!pausePanel.activeSelf);
			
			if (pausePanel.activeSelf == true) {Time.timeScale = 0;}
			else if (pausePanel.activeSelf == false) {Time.timeScale = 1;}
		}
		
		// Permite o controle
		if (controllerActive) {
			// Reseta a posição
			if (Input.GetButtonDown("Reset")) {StartCoroutine(ResetPosition());}
		
			// Muda o ângulo da câmera
			if (Input.GetButtonDown("CamSwitch")) {CameraSwitch();}
			
			// Permite o mergulho
			if (diveActive) {
				if (Input.GetButtonDown("Dive")) {StartCoroutine(Dive());}
			}
			
			// Controle de navegação ou de mergulho?
			if (sailing == true) {
				Sail();
			} else {
				Swim();
			}
		}
		
		// Mostra o save atual
		Debug.Log("Pickups: " + saveData.pickups.ToString() + " Name: " + saveData.playerName);
	}
	
	// Controle da Navegação
	void Sail() {
		float y = Input.GetAxis("Horizontal");
		
		if (Input.GetButton("FullSpeed")) {
			// Velocidade Rápida
			if (Input.GetButton("Accel")) {transform.Translate(0,0,1*sailSpeed*2); waterSplashEmission.rate = 400; waterSplash.Play();}
			else {waterSplash.Stop();}
			transform.Rotate(0,y*sailRotationSpeed,0);
		} else {
			// Velocidade Normal
			if (Input.GetButton("Accel")) {transform.Translate(0,0,1*sailSpeed); waterSplashEmission.rate = 200; waterSplash.Play();}
			else {waterSplash.Stop();}
			transform.Rotate(0,y*sailRotationSpeed,0);
		}
		
		// Animação
		trirremeAnim.SetFloat("trirremeRotation", y);
		trirremeAnim.SetBool("throttle", Input.GetButton("Accel"));
	}
	
	// Controle do Mergulho
	void Swim() {
		waterSplash.Stop();
		
		float y = Input.GetAxis("Horizontal");
		float x = Input.GetAxis("Vertical");
		
		if (Input.GetButton("FullSpeed")) {
			// Velocidade Rápida
			if (Input.GetButton("Accel")) {transform.Translate(0,0,1*swimSpeed*2);}
			transform.Rotate(-x*swimRotationSpeed,0,0);
			transform.Rotate(0,y*swimRotationSpeed,0, Space.World);
		} else {
			// Velocidade Normal
			if (Input.GetButton("Accel")) {transform.Translate(0,0,1*swimSpeed);}
			transform.Rotate(-x*swimRotationSpeed,0,0);
			transform.Rotate(0,y*swimRotationSpeed,0, Space.World);
		}
		
		// Animação
		trirremeAnim.SetFloat("trirremeRotation", y);
	}
	
	// Realiza o mergulho
	IEnumerator Dive() {
		// Ativa a distorção da tela
		waterDistortion.SetActive(true);
		
		for (float i = 0; i < 4; i += 0.1f) {
			transform.Translate(0,-transform.position.y-i,0, Space.World);
			// Ativa o fog
			RenderSettings.fogDensity += 0.001f;			
			yield return new WaitForSeconds(0.01f);
		}
		
		// Troca de movimento
		sailing = false;
		// Desativa o mergulho
		diveActive = false;
		// Ativa a superfície
		surface.enabled = true;
	}
	
	// Volta à superfície
	IEnumerator Surface() {
		// Desativa o controle
		controllerActive = false;
		// Desativa a superfície
		surface.enabled = false;
		
		transform.DOMoveY(0.56f,2,false);
		
		// Desativa o fog
		while (RenderSettings.fogDensity > 0) {RenderSettings.fogDensity -= 0.01f; yield return new WaitForSeconds(0.1f);}
		
		// Desativa a distorção da tela
		waterDistortion.SetActive(false);
		
		transform.DORotate(new Vector3(0,transform.rotation.y,0),1.5f,RotateMode.Fast).SetEase(Ease.OutSine);
		
		// Troca de movimento
		sailing = true;
		// Ativa o controler
		controllerActive = true;
		// Ativa o mergulho
		diveActive = true;
		
		yield return null;
	}
	
	// Reseta a posição
	IEnumerator ResetPosition() {
		// Desativa o controle
		controllerActive = false;
		
		transform.position = originalPosition;
		
		// Faz o barco piscar
		for (int i = 0; i < 6; i++) {
			trirreme.SetActive(!trirreme.activeSelf);
			yield return new WaitForSeconds(0.1f);
		}
		
		// Ativa o controle
		controllerActive = true;
	}
	
	// Muda o ângulo da câmera
	void CameraSwitch() {
		cameraLeft = !cameraLeft;
		
		if (cameraLeft) {
			camera.transform.DORotate(new Vector3(0,13,0), 1, RotateMode.Fast);
			camera.transform.DOMove(leftAngle.position, 1, false);
		} else {
			camera.transform.DORotate(new Vector3(0,-13,0), 1, RotateMode.Fast);
			camera.transform.DOMove(rightAngle.position, 1, false);
		}
	}
	
	// Colisão
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Surface") {
			StartCoroutine(Surface());
		}
	}
}