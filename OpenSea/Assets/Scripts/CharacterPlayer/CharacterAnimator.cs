using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    NavMeshAgent agent;

    [HideInInspector]
    public Animator anim;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("speedPercent", speedPercent, 0.1f, Time.deltaTime);
	}
}
