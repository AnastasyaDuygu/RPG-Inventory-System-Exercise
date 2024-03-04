using UnityEngine;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour
{
    [SerializeField] Image icon;
    public Item item;

    public bool isEmpty = true;

    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        isEmpty = false;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        isEmpty = true;
    }
    public void OnSlotButtonClicked()
    {
        if (isEmpty) return; // do nothing if slot is empty
        //
        UseItem();
        Inventory.Instance.Remove(item);
    }
    private void UseItem()
    {
        if (item == null) return;
        item.Use();
    }
}
