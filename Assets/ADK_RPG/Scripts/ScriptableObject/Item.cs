using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefault = false;
    public GameObject prefab = null;
    public virtual void Use()
    {
        //overridde
        //TODO: if button right click use item, else drop item onto the environment
        Debug.Log("Using " + name);
    }
}
