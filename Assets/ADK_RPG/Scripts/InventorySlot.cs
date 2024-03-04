using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class InventorySlot : MonoBehaviour, IPointerClickHandler
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
    private bool UseItem()
    {
        return item.Use();
    }

    private bool DropItem()
    {
        return item.Drop();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (item == null) return;

        bool isUsable = true;
        bool isDropped = true;
        
        if (isEmpty) return; // do nothing if slot is empty
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isUsable = UseItem();
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            isDropped = DropItem();
        }
        if (!isUsable || !isDropped) return; // do not remove object if not usable or it couldn't be dropped
        Inventory.Instance.Remove(item);
    }
}
