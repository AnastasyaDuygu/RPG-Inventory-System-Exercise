using DG.Tweening;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;
    public GameObject prefab = null;
    public virtual bool Use()
    {
        //overridde
        //TODO: if button right click use item, else drop item onto the environment
        Debug.Log("Using " + name);

        //on default items are usable
        return true;
    }

    public virtual bool Drop()
    {
        if (prefab == null) return false; 
        var pos = FindObjectOfType<PlayerController>().transform.position;
        pos.y = 0.783f; //default height from ground
        GameObject coinGameObject = Instantiate(prefab, pos, Quaternion.identity);

        var randomAngle = Random.Range(0f, 360f);
        var randomDistance = Random.Range(0.5f, 1);
        var randomVector = Quaternion.AngleAxis(randomAngle, Vector3.up) * (randomDistance * Vector3.forward);
        coinGameObject.transform.DOJump(coinGameObject.transform.position + Vector3.forward + randomVector, 1, 1, 0.25f);

        Debug.Log("Dropped " + name);
        return true;
    }
}
