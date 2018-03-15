using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using DG.Tweening;

public class CrystalKeyInteraction : Interactable {

    public GameObject key;
    public PlayableDirector timeline;

    public Vector3 movePosition;
    public float moveDuration;

    private void Start() {
        //Start key floating loop
        key.transform.DOMove(movePosition + key.transform.position, moveDuration).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

    //when player interacts
    public override void Interact() {
        base.Interact();
        //kill the loop
        DOTween.KillAll();

        //move key into position of the start frame of the timeline animation
        key.transform.DOMove(new Vector3(0,7.3f,0) + key.transform.position, moveDuration).SetEase(Ease.InOutSine);

        //shake the camera for some reason
        Camera.main.DOShakePosition(3,1);
        
        //start the timeline animation
        timeline.Play();
    }
}
