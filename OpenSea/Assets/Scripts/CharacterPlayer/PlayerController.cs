using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    public Interactable focus;

    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

    void Start() {

        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //Left mouse click to move 
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit, 100, movementMask)) {
                motor.MoveToPoint(hit.point);
                RemoveFocus();
            }
        }

        //Right mouse click to interact
        if (Input.GetMouseButtonDown(1)) {
            if (Physics.Raycast(ray, out hit, 100)) {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) {
                    SetFocus(interactable);
                }
            }
        }
    }

    void SetFocus(Interactable newFocus) {
        if(newFocus != focus) {
            if(focus != null)
                focus.OnDeFocus();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocus(transform);
    }

    void RemoveFocus() {
        if (focus != null)
            focus.OnDeFocus();

        focus = null;
        motor.StopFollowingTarget();
    }
}
