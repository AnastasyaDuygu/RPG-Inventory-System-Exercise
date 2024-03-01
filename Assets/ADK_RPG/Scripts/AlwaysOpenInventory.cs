using UnityEngine;

public class AlwaysOpenInventory : MonoBehaviour
{
    [SerializeField] InventoryUI inventoryUI;

    Inventory inventory;
    InventorySlot[] alwaysOpenSlots;
    //when ui is update and if all 7 slots of always open inventory is not full project item to always open inventory

    private void Start()
    {
        alwaysOpenSlots = transform.GetComponentsInChildren<InventorySlot>();
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateAlwaysOpenInventory; //subscribing method to the event, now UpdateUI will be called when event is triggered
    }
    void UpdateAlwaysOpenInventory()
    {
        var slotsArray = inventoryUI.getSlots();
        if (slotsArray == null) return;
        Debug.Log("SLOTS IS NOT EMPTY");
        for (int i = 0; i < slotsArray.Length; i++)
        {
            if (i >= alwaysOpenSlots.Length) break; //no more open slots
            alwaysOpenSlots[i] = slotsArray[i];
            Debug.Log("Add Item To Open Canvas : " + alwaysOpenSlots[i]); //not correct
            //alwaysOpenSlots[i].AddItem(slotsArray[i].item);
        }
    }
}
