using UnityEngine;

public class Interactable : MonoBehaviour {

    public float radius = 3;
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact() {
        //Override this guy!!
    }

    void Update() {
        if (isFocus && !hasInteracted) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if(distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }

    public void OnFocus(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocus() {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected() {

        if (interactionTransform == null)
            interactionTransform = transform;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
