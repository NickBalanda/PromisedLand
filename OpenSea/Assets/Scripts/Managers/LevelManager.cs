using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class LevelManager : MonoBehaviour {

    public Image faderImg;

    public static LevelManager instance;
    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            instance = this;
        }
    }
    void Start () {
        faderImg.color = new Color32(0, 0, 0, 255);
        faderImg.DOFade(0, 3).SetDelay(1);
	}

    public void PlayerKilled() {
        StartCoroutine(PlayerDead());
    }

    IEnumerator PlayerDead() {
        Tween myTween = faderImg.DOColor(new Color32(140,0,0,135), 0.2f);

        yield return myTween.WaitForCompletion();

        faderImg.color = new Color32(0, 0, 0, 0);


        faderImg.DOFade(1, 3);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
