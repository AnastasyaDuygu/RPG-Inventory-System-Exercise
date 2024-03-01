using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField] private Item item;
    public override void Interact()
    {
        base.Interact();
        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.Instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);

    }
}
