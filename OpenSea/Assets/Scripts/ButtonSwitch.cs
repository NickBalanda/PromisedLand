using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonSwitch : Interactable {

    //materials to give feedback on button state
    public Material onMaterial;
    public Material offMaterial;

    //is the button on?
    public bool isOn;

    //can you turn the button on and off, or press it once?
    public bool toggleButton = true;

    [Space(10)]
    [SerializeField] 
    public UnityEvent onButtonPressed = new UnityEvent(); 

    [SerializeField] 
    public UnityEvent offButtonPressed = new UnityEvent();

    private MeshRenderer mr;

    void Start () {
        mr = GetComponent<MeshRenderer>();
        if (isOn) {
            mr.material = onMaterial;
        } else {
            mr.material = offMaterial;
        }
	}

    public override void Interact() {
        base.Interact();
        isOn = !isOn;

        if (isOn) {
            mr.material = onMaterial;
            onButtonPressed.Invoke();
        } else {
            mr.material = offMaterial;
            offButtonPressed.Invoke();
        }

        if (!toggleButton) {
            enabled = false;
        }
    }
}
