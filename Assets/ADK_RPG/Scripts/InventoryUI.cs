using System;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform slotsAlwaysOpenParent;
    [SerializeField] Transform slotsParent;
    [SerializeField] GameObject inventoryCanvas;
    InventorySlot[] slotsAlwaysOpen;
    InventorySlot[] slots;

    Inventory inventory;

    void Start()
    {
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
        //
        slotsAlwaysOpen = slotsAlwaysOpenParent.GetComponentsInChildren<InventorySlot>();
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI; //subscribing method to the event, now UpdateUI will be called when event is triggered
    }
    void Update()
    {
        if (Input.GetKeyDown("i")){
            inventoryCanvas.SetActive(!inventoryCanvas.activeSelf);
        }
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
        var lastSlot = slotsAlwaysOpen[slotsAlwaysOpen.Length - 1];
        if (lastSlot != null) //if always open slots are NOT full
        {
            for (int i = 0; i < slotsAlwaysOpen.Length; i++)
            {
                if (i < inventory.items.Count) //there are items to add
                {
                    slotsAlwaysOpen[i].AddItem(inventory.items[i]);
                }
                else
                {
                    slotsAlwaysOpen[i].ClearSlot();
                }
            }
        }
        else //if always open slots ARE full
        {
            for(int i = 0;i < slots.Length; i++)
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
    /*public InventorySlot[] getSlots()
    {
        return slotsAlwaysOpen;
    }*/

    public void OnCloseButtonClicked()
    {
        inventoryCanvas.SetActive(false);
    }
}
