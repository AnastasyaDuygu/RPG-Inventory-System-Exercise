using DG.Tweening;
using UnityEngine;

[CreateAssetMenu(fileName = "New Coin", menuName = "Inventory/Item/Coin")]
public class CoinItem : Item
{
    public override void Use()
    {
        base.Use();
        var pos = FindObjectOfType<PlayerController>().transform.position;
        pos.y = 0.783f; //default height from ground
        GameObject coinGameObject = Instantiate(prefab, pos, Quaternion.identity);
        
        var randomAngle = Random.Range(0f, 360f);
        var randomDistance = Random.Range(0.5f, 1);
        var randomVector = Quaternion.AngleAxis(randomAngle, Vector3.up) * (randomDistance * Vector3.forward);
        coinGameObject.transform.DOJump(coinGameObject.transform.position + Vector3.forward + randomVector, 1, 1, 0.25f);

    }
}
