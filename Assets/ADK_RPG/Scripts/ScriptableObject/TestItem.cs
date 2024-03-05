using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Test")]
public class TestItem : Item
{
    PlayerStats playerStats;
    public override bool Use()
    {
        //health regen
        playerStats = FindObjectOfType<PlayerStats>();
        if (playerStats.currentHealth >= 100)
        {
            Debug.Log("Health is already full!");
            return false; //player cannot use item if they have full health
        }
        if (playerStats.currentHealth > 90)
        {
            playerStats.currentHealth = 100; //if player has greater than 90 health the item will just complete it to 100 health
            return true;
        }
        playerStats.currentHealth += 10;
        Debug.Log("Health increased with " + name);
        return true;
    }
}
