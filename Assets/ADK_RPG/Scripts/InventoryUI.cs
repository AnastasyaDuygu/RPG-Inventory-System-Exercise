using System;
using System.Linq;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform slotsAlwaysOpenParent;
    [SerializeField] Transform slotsParent;
    [SerializeField] GameObject inventoryCanvas;
    InventorySlot[] slotsAlwaysOpen;
    InventorySlot[] slots;
    public InventorySlot[] allSlots;

    Inventory inventory;

    void Start()
    {
        slotsAlwaysOpen = slotsAlwaysOpenParent.GetComponentsInChildren<InventorySlot>();
        slots = slotsParent.GetComponentsInChildren<InventorySlot>();
        allSlots = slotsAlwaysOpen.Concat(slots).ToArray();
        //
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

        for (int i = 0; i < allSlots.Length; i++)
        {
            if (i < inventory.items.Count) //there are items to add
            {
                allSlots[i].AddItem(inventory.items[i]);
            }
            else
            {
                allSlots[i].ClearSlot();
            }
        }
    }
    public void OnCloseButtonClicked()
    {
        inventoryCanvas.SetActive(false);
    }
}
