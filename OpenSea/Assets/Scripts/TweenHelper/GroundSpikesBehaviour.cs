using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GroundSpikesBehaviour : MonoBehaviour {

    public bool playOnStart = true;

    public float upDelay, downDelay;

    //Move
    public Vector3 movePosition;
    public float moveDuration;
    public bool localMove;

    public Ease ease = Ease.Linear;

    //private
    Vector3 startPosition;
    bool start;

    void Start() {
        start = true;
        startPosition = transform.position;

        if(playOnStart)
            StartCoroutine(SomeCoroutine());
    }

    public void Up() {
        
    }

    public void Down() {
        
    }

    IEnumerator SomeCoroutine() {

        Tween myTween;
        while (true) {

            if (localMove)
                myTween = transform.DOLocalMove(movePosition + startPosition, moveDuration).SetEase(ease).SetDelay(upDelay);
            else
                myTween = transform.DOMove(movePosition + startPosition, moveDuration).SetEase(ease).SetDelay(upDelay);

            yield return myTween.WaitForCompletion();
            // This log will happen after the tween has completed

            if (localMove)
                myTween = transform.DOLocalMove(new Vector3(0,0,0) + startPosition, moveDuration).SetEase(ease).SetDelay(downDelay);
            else
                myTween = transform.DOMove(new Vector3(0, 0, 0) + startPosition, moveDuration).SetEase(ease).SetDelay(downDelay);

            yield return myTween.WaitForCompletion();
        }
       
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        if (!start) {
            Gizmos.DrawWireSphere(movePosition + transform.position, 0.5f);
            Gizmos.DrawLine(transform.position, movePosition + transform.position);
        }
    }
}
