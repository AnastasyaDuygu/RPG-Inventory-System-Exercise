using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform slotsParent;
    InventorySlot[] slots;

    Inventory inventory;

    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI; //subscribing method to the event, now UpdateUI will be called when event is triggered
    }
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count) //there are items to add
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();    
            }
        }
    }
}
