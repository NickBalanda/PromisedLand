using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour {

	void Awake() {DontDestroyOnLoad(gameObject);}
	
	// Carrega uma cena
	public void SmoothLoadScene(string scene) {StartCoroutine(AsyncLoad(scene));}
	
	// Sai do jogo
	public void QuitGame() {Application.Quit();}
	
	// Carrega a cena em segundo plano
	IEnumerator AsyncLoad(string scene) {
		// Passa para a cena de loading
		SceneManager.LoadSceneAsync("LoadingScreen");
		
		// Carrega a cena em segundo plano
		AsyncOperation operation = SceneManager.LoadSceneAsync(scene);
		
		// Espera a operação terminar
		while (!operation.isDone) {
			yield return null;
		}
	}
}