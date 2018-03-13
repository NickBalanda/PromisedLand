using UnityEngine;

public class Pickup : Interactable {

    public override void Interact() {
        base.Interact();

        // Adiciona um item no save
        SaveLoadManager.instance.pickups += 1;
        PlayerPrefs.SetInt("pickups" + SaveLoadManager.instance.slot, SaveLoadManager.instance.pickups);

        // Destrói o item
        Destroy(gameObject);
    }
}
