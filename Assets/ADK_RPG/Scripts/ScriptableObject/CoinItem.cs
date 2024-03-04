using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Inventory/Item/Coin")]
public class CoinItem : Item
{
    public override bool Use()
    {
        //coin is NOT usable
        Debug.Log("Item " + name + " is NOT usable");
        return false;
    }
}
