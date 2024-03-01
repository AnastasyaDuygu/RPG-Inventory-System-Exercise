using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    Inventory inventory;

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI; //subscribing method to the event, now UpdateUI will be called when event is triggered
    }
    void Update()
    {
        
    }

    void UpdateUI()
    {
        Debug.Log("Updating UI");
    }
}
