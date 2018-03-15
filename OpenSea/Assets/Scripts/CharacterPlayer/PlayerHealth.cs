using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public bool isDead = false;

    CharacterAnimator ca;
    PlayerController pc;
    PlayerMotor pm;
	// Use this for initialization
	void Start () {
        ca = GetComponent<CharacterAnimator>();
        pc = GetComponent<PlayerController>();
        pm = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Death")) {
            if (!isDead) {
                print("U dead!");
                ca.anim.SetBool("isDead", true);
                pc.enabled = false;
                pm.agent.isStopped = true;
                LevelManager.instance.PlayerKilled();
                isDead = true;
            }
        }
    }
}
