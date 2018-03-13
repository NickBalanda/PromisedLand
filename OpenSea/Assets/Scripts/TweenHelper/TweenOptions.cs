using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenOptions : MonoBehaviour {

    public enum TweenType { Move, Scale, Rotate, Color, Path, Shake };
    public TweenType myTweenType = TweenType.Move;

    public bool playOnStart = true;

    public float startDelay;

    //Move
    public Vector3 movePosition;
    public float moveDuration;
    public bool localMove;

    //Scale
    public float scaleDuration;
    public float scaleSize;

    //Rotation
    public Vector3 rotatePosition;
    public float rotateDuration;
    public RotateMode rotateMode = RotateMode.FastBeyond360;

    //Color
    SpriteRenderer ren;
    public Color color;
    public float colorDuration;

    //Path
    public Vector3[] waypoints;
    public float pathDuration;
    public bool closePath;
    public PathType pathType;
    public PathMode pathMode;
    public bool localPath;

    //Shake
    public bool shakePosition = true;
    public bool shakeRotation;
    public bool shakeScale;

    //shake position
    public float shakePduration;
    public float shakePstrenght = 1;
    public int shakePvibrato = 10;
    public float shakePrandomness = 90;
    public bool shakePsnapping = false;
    public bool shakePfadeOut = true;
    
    //shake rotation
    public float shakeRduration;
    public float shakeRstrenght = 90;
    public int shakeRvibrato = 10;
    public float shakeRrandomness = 90;
    public bool shakeRfadeOut = true;
    //shake scale
    public float shakeSduration;
    public float shakeSstrenght = 1;
    public int shakeSvibrato = 10;
    public float shakeSrandomness = 90;
    public bool shakeSfadeOut = true;


    //Other settings
    public int numLoops;
    public float delayBetweenLoops;
    public LoopType loopeType = LoopType.Incremental;
    public Ease ease = Ease.Linear;

    //private
    Vector3 startPosition;
    bool start;

    void Start() {
        start = true;
        startPosition = transform.position;
        if (GetComponent<SpriteRenderer>() != null) {
            ren = GetComponent<SpriteRenderer>();
        }

        if (playOnStart) {
            StartTweening();
        }
    }

    public void StartTweening() {
        switch (myTweenType) {
            case TweenType.Move:
                if (localMove)
                    transform.DOLocalMove(movePosition + startPosition, moveDuration).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                else
                    transform.DOMove(movePosition + startPosition, moveDuration).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                break;
            case TweenType.Scale:
                //Debug.Log ("Scale");
                transform.DOScale(scaleSize, scaleDuration).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                break;
            case TweenType.Rotate:
                //Debug.Log ("Rotate");
                transform.DOLocalRotate(rotatePosition, rotateDuration, rotateMode).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                break;
            case TweenType.Color:
                //Debug.Log ("Color");
                if (ren != null) {
                    ren.DOColor(color, colorDuration).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                } else {
                    Debug.Log("You need a SpriteRenderer component!");
                }
                break;
            case TweenType.Path:
                //Debug.Log("Path");
                for (int i = 0; i < waypoints.Length; i++) {
                    waypoints[i] += transform.position;
                }

                if (localPath)
                    transform.DOLocalPath(waypoints, pathDuration, pathType, pathMode).SetOptions(closePath).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                else
                    transform.DOPath(waypoints, pathDuration, pathType, pathMode).SetOptions(closePath).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                break;
            case TweenType.Shake:
                if (shakePosition) {
                    transform.DOShakePosition(shakePduration, shakePstrenght, shakePvibrato, shakePrandomness, shakePsnapping, shakePfadeOut).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                }
                if (shakeRotation) {
                    transform.DOShakeRotation(shakeRduration, shakeRstrenght, shakeRvibrato, shakeRrandomness, shakeRfadeOut).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                }
                if (shakeScale) {
                    transform.DOShakeScale(shakeSduration, shakeSstrenght, shakeSvibrato, shakeSrandomness, shakeSfadeOut).SetDelay(startDelay).SetLoops(numLoops, loopeType).SetEase(ease);
                }
                break;
        }

    }

    public void PauseTween() {
        DOTween.PauseAll();
    }
    public void ResumeTween() {
        DOTween.PlayAll();
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;

        if (!start) {
            if (myTweenType == TweenType.Path) {

                for (int i = 0; i < waypoints.Length; i++) {
                    Gizmos.DrawWireSphere(waypoints[i] + transform.position, 0.5f);
                    if (i + 1 < waypoints.Length) {
                        Gizmos.DrawLine(waypoints[i] + transform.position, waypoints[i + 1] + transform.position);
                    }

                }
            }
            if (myTweenType == TweenType.Move) {

                Gizmos.DrawWireSphere(movePosition + transform.position, 0.5f);
                Gizmos.DrawLine(transform.position, movePosition + transform.position);

            }

        }

    }
}
