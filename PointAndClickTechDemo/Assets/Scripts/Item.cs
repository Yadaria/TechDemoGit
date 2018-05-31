using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 1)]
public class Item: ScriptableObject
{
    //public Sprite image;

    public string itemName;

    public string itemText;

    public string picture;

    // Use this for initialization
    void Start()
    {

    }    
}
