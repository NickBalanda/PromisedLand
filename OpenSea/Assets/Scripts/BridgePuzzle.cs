using UnityEngine;
using DG.Tweening;

public class BridgePuzzle : MonoBehaviour {

    public TweenOptions gateAnim;
    //Platforms
    public GameObject platformA, platformB, platformC, platformD;

    public ButtonSwitch[] buttons; 
    //Check if each platform is up or down
    bool is_A_Up, is_B_Up, is_C_Up, is_D_Up;

    public float up_Y_Value, down_Y_Value;

    public float moveDuration = 2;
    
    void Start () {
		
	}

    public void Button1() {
        // B&C
        if (is_B_Up) {
            platformB.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformB.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }

        if (is_C_Up) {
            platformC.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformC.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }

        is_B_Up = !is_B_Up;
        is_C_Up = !is_C_Up;
        CheckIfPuzzleCompleted();
    }
    public void Button2() {
        //B&D
        if (is_B_Up) {
            platformB.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformB.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }
        if (is_D_Up) {
            platformD.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformD.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }
        is_B_Up = !is_B_Up;
        is_D_Up = !is_D_Up;
        CheckIfPuzzleCompleted();
    }
    public void Button3() {
        //C
        if (is_C_Up) {
            platformC.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformC.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }

        is_C_Up = !is_C_Up;
        CheckIfPuzzleCompleted();
    }
    public void Button4() {
        //A&B
        if (is_A_Up) {
            platformA.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformA.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }
        if (is_B_Up) {
            platformB.transform.DOLocalMoveY(down_Y_Value, moveDuration);
        } else {
            platformB.transform.DOLocalMoveY(up_Y_Value, moveDuration);
        }
        is_A_Up = !is_A_Up;
        is_B_Up = !is_B_Up;
        CheckIfPuzzleCompleted();
    }
    void CheckIfPuzzleCompleted() {
        if(is_A_Up && is_B_Up && is_C_Up && is_D_Up) {
            gateAnim.StartTweening();
            Camera.main.DOShakePosition(2);
            foreach (ButtonSwitch btn in buttons) {
                btn.enabled = false;
            }
        }
    }
}
