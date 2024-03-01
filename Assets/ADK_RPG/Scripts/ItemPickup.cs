using UnityEngine;

public class ItemPickup : Interactable
{
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up item");
        Destroy(gameObject);
    }
}
