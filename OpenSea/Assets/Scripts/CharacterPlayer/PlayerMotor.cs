using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

    Transform target;

    [HideInInspector]
    public NavMeshAgent agent;
    // Use this for initialization
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        if(target != null) {
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point) {
        agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget) {
        agent.stoppingDistance = newTarget.radius * 0.9f;
        agent.updateRotation = false;

        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget() {
        target = null;
        agent.stoppingDistance = 0;
        agent.updateRotation = true;
    }

    void FaceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }
}
